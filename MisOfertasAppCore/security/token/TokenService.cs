using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.model;


namespace MisOfertasAppCore.data.security.token
{
   public class TokenService
    {


        public string GenerateToken(string reason, Usuario usuario)
        {
            Encoding enc = Encoding.UTF8;


            /* byte[] _time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
             byte[] _key = Guid.Parse(usuario.SECURITYSTAMP).ToByteArray();
             byte[] _Id = enc.GetBytes(usuario.ID_USUARIO.ToString());
             byte[] _reason = enc.GetBytes(reason);
             byte[] data = new byte[_time.Length + _key.Length + _reason.Length + _Id.Length];

             System.Buffer.BlockCopy(_time, 0, data, 0, _time.Length);
             System.Buffer.BlockCopy(_key, 0, data, _time.Length, _key.Length);
             System.Buffer.BlockCopy(_reason, 0, data, _time.Length + _key.Length, _reason.Length);
             System.Buffer.BlockCopy(_Id, 0, data, _time.Length + _key.Length + _reason.Length, _Id.Length);*/

            /* return Convert.ToBase64String(data.ToArray());*/

            return null;
        }



        public TokenValidation ValidateToken(string reason, Usuario usuario, string token)
        {
            Encoding enc = Encoding.UTF8;

            var result     = new TokenValidation();
            byte[] data    = Convert.FromBase64String(token);
            byte[] _time   = data.Take(8).ToArray();
            byte[] _key    = data.Skip(8).Take(16).ToArray();
            byte[] _reason = data.Skip(24).Take(6).ToArray();
            byte[] _Id     = data.Skip(30).ToArray();

            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(_time, 0));
            if (when < DateTime.UtcNow.AddHours(-24))
            {
                result.Errors.Add(TokenValidationStatus.Expired);
            }

           /* Guid gKey = new Guid(_key);
            if (gKey.ToString() != usuario.SECURITYSTAMP)
            {
                result.Errors.Add(TokenValidationStatus.WrongGuid);
            }*/
            

            if (reason != enc.GetString(_reason))
            {
                result.Errors.Add(TokenValidationStatus.WrongPurpose);
            }

            if (usuario.ID_USUARIO.ToString() != enc.GetString(_Id))
            {
                result.Errors.Add(TokenValidationStatus.WrongUser);
            }

            return result;
        }


    }
}
