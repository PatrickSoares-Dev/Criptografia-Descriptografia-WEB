using PgpCore;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Install-Package PgpCore -Version 1.2.0
            using (PGP pgp = new PGP())
            {
                //pgp.EncryptFile(@"C:\Users\rafael.alves\Desktop\MVNO\Criptografica\TLC12346.INP", @"C:\Users\rafael.alves\Desktop\MVNO\Criptografica\content__encrypted.pgp", @"C:\Users\rafael.alves\Desktop\MVNO\Criptografica\keys\pfk.asc", true, true);
                //pgp.EncryptFile(@"C:\Users\rafael.alves\Desktop\MVNO\crip\CripThiago", @"C:\Users\rafael.alves\Desktop\MVNO\crip\content__encryptedTestando.pgp", @"C:\Users\rafael.alves\Desktop\MVNO\crip\testePK.asc", true, true);
                //pgp.EncryptFile(@"C:\tmp\tmpcrip\cripalvo", @"C:\tmp\tmpcrip\content__encryptedTestando.pgp", @"C:\Users\rafael.alves\Desktop\MVNO\crip\testePK.asc", true, true);
                //pgp.EncryptFile(@"C:\tmp\tmpcrip\cripalvo", @"C:\tmp\tmpcrip\teste.pgp", @"C:\tmp\tmpcrip\chavebarba.asc", true, true);
                //pgp.de
                string stmp = "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%";
            }

        }
    }
}
