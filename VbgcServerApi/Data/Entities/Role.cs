﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VbgcServerApi.Data.Entities
{
	public class Role
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int RoleId { get; set; }
		[Required]
		public string RoleName { get; set; }
		public virtual ICollection<UserInRole> UserInRoles { get; set; }
	}
}
