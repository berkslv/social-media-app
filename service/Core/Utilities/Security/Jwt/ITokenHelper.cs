using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Concrete;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(UserBase user, List<OperationClaim> operationClaims);
    }
}
