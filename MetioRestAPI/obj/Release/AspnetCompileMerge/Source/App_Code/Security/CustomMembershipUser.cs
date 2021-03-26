using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MetioRestAPI.App_Code.Security
{
    public class CustomMembershipUser : MembershipUser
    {
        public int ClientID { get; set; }
        public RoleDTO Role { get; set; }

        public CustomMembershipUser(ClientDTO client,RoleDTO role)
            : base("CustomMembership",
                client.login,
                client.client_id,
                "nonde",
                string.Empty,
                string.Empty,
                true,
                false,
                DateTime.Now,
                DateTime.Now,
                DateTime.Now,
                DateTime.Now,
                DateTime.Now)
        {
            ClientID = client.client_id;
            Role = role;
        }
    }
}