using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using VbgcServerApi.Data;
using VbgcServerApi.Data.Entities;
using VbgcServerApi.Infrastructure.BusinessRules;
using VbgcServerApi.Infrastructure.Dto;
using VbgcServerApi.Infrastructure.Helpers;

namespace VbgcServerApi.Services
{
	public class UserService : IUserService
    {
		private DataContext context;
		private readonly IMapper mapper;

		public UserService(DataContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public UserDto Authenticate(string username, string password)
		{
			if (string.IsNullOrEmpty(username))
				throw new UsernameIsRequiredException();

			if (string.IsNullOrEmpty(password))
				throw new PasswordIsRequiredException();

			var user = context.Users.Where(o => o.Username == username).SingleOrDefault();
			if (user == null)
				throw new UsernamePasswordIncorrectException();

			// check if password is correct
			if (!AuthHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
				throw new UsernamePasswordIncorrectException();

			// authentication successful
			return mapper.Map<UserDto>(user);
		}

		public IEnumerable<UserDto> GetAll()
		{
			return mapper.Map<IEnumerable<UserDto>>(context.Users);
		}

		public UserDto GetById(int id)
		{
			return mapper.Map<UserDto>(context.Users.Find(id));
		}

		public UserDto Create(RegisterDto user)
		{
			var entity = mapper.Map<User>(user);

			// validation
			if (string.IsNullOrWhiteSpace(user.Password))
				throw new PasswordIsRequiredException();

			if (context.Users.Where(o => o.Username == user.Username).Any())
				throw new DuplicateConsraintException();

			byte[] passwordHash, passwordSalt;
			AuthHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

			entity.PasswordHash = passwordHash;
			entity.PasswordSalt = passwordSalt;

			context.Add(entity);
			context.SaveChanges();

			return mapper.Map<UserDto>(entity);
		}

		public void Update(UserDto dto, string password = null)
		{
			User userParam = mapper.Map<User>(dto);

			var user = context.Users.Where(o => o.UserId == userParam.UserId).SingleOrDefault();
			if (user == null)
				throw new NotFoundException();

			if (userParam.Username != user.Username)
			{
				// username has changed so check if the new username is already taken
				if (context.Users.Any(x => x.Username == userParam.Username))
					throw new DuplicateConsraintException();
			}

			// update user properties
			user.FirstName = userParam.FirstName;
			user.LastName = userParam.LastName;
			user.Username = userParam.Username;

			// update password if it was entered
			if (!string.IsNullOrWhiteSpace(password))
			{
				byte[] passwordHash, passwordSalt;
				AuthHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

				user.PasswordHash = passwordHash;
				user.PasswordSalt = passwordSalt;
			}

			context.Update(user);
			context.SaveChanges();
		}

		public void UpdateRoles(int id, List<RoleDto> roles)
		{
			var user = context.Users.Find(id);
			if (user == null)
				throw new NotFoundException();

			user.UserInRoles.Clear();
			foreach (var role in roles)
			{
				user.UserInRoles.Add(new UserInRole { RoleId = role.RoleId, UserId = user.UserId });
			}

			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var user = context.Users.Find(id);
			if (user != null)
			{
				context.Remove(user);
				context.SaveChanges();
			}
		}
	}
}
