using System;
using System.Linq;
using System.Threading.Tasks;
using dating_app.models;

namespace dating_app.models {
    public class authrepo : authrepositry {
        StoreAppContext _context;
        public authrepo (StoreAppContext context) {
            _context = context;
        }
        public bool exist(string username)
        {
            var user = _context.users.FirstOrDefault(p => p.Name == username);
            if (user == null)
                return false;
            else return true;
        }

        public user login(string username, string pass)
        {

            var user = _context.users.FirstOrDefault(p => p.Name == username);

            if (user == null)
                return null;

            if (!verfy(pass, user.hash, user.salt))
                return null;

            return user;

        }

        private bool verfy (string pass, byte[] hash, byte[] salt) {
            using (var h = new System.Security.Cryptography.HMACSHA256 (salt)) {

                var cumputed = h.ComputeHash (System.Text.Encoding.UTF8.GetBytes (pass));
                for (int i = 0; i < cumputed.Length; i++) {
                    if (cumputed[i] != hash[i])
                        return false;
                }
                return true;

            }

        }

        public user register (user u, string pass) {
            byte[] hash, salt;

            creathash (pass, out hash, out salt);

            u.hash = hash;
            u.salt = salt;
             _context.users.AddAsync (u);
            _context.SaveChanges ();
            return u;
        }

        private void creathash (string pass, out byte[] hash, out byte[] salt) {
            using (var h = new System.Security.Cryptography.HMACSHA256 ()) {

                salt = h.Key;
                hash = h.ComputeHash (System.Text.Encoding.UTF8.GetBytes (pass));

            }

        }

        

       
    }
}