using PgpCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PGP pgp = new PGP())
            {
                //pgp.EncryptFile(@"C:\Users\rafael.alves\Desktop\MVNO\Criptografica\TLC12346.INP", @"C:\Users\rafael.alves\Desktop\MVNO\Criptografica\content__encrypted.pgp", @"C:\Users\rafael.alves\Desktop\MVNO\Criptografica\keys\pfk.asc", true, true);
                 pgp.EncryptFile(@"C:\Users\rafael.alves\Desktop\MVNO\Criptografica\TLC12346.INP", @"C:\Users\rafael.alves\Desktop\MVNO\Criptografica\content__encrypted2.pgp", @"C:\Users\rafael.alves\Desktop\MVNO\Criptografica\keys\feil.asc", true, true);
            }

        }
    }
}
