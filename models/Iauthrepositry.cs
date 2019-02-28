using System;
using System.Threading.Tasks;

namespace dating_app.models
{
    public interface authrepositry
    {
          user register(user u, String pass );
         user login(String username, String pass );
         bool exist(String username);

    }
}