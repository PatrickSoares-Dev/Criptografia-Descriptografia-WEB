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
                //pgp.EncryptFile(@"C:\Users\rafael.alves\Desktop\MVNO\Criptografica\TLC12346.INP", @"C:\Users\rafael.alves\Desktop\MVNO\Criptografica\content__encrypted.pgp", @"C:\Users\rafael.alves\Desktop\MVNO\Criptografica\keys\pfk.asc", true, true);
                //string[] aChaves = new string[]{ @"D:\LinksFieldMeu\IntelcavKey.asc", @"D:\LinksFieldMeu\linksfield_publickey.asc", @"D:\LinksFieldMeu\linksfieldbrasil_publickey.asc", @"D:\LinksFieldMeu\watchdata.asc" };
                //string[] aChaves = new string[] { @"D:\LinksFieldMeu\IntelcavKey.asc", @"D:\LinksFieldMeu\linksfield_publickey.asc", @"D:\LinksFieldMeu\watchdata.asc", @"D:\LinksField\linksfield_pk_brasil.asc" };
                //string[] aChaves = new string[] { @"D:\Public Keys\PARETEUM\Teumpub.asc" };
                //string[] aChaves = new string[] { @"D:\Public Keys\PARETEUM\Teumpub.asc", @"D:\Public Keys\PARETEUM\PTSecure.asc" };
                //string[] aChaves = new string[] { @"D:\Public Keys\PARETEUM\PTSecure.asc", @"D:\Public Keys\PARETEUM\Ramy Sayed.asc", @"D:\Public Keys\PARETEUM\Teumpub.asc" };
                string[] aChaves = new string[] { @".\chavepub.asc"};
                //pgp.EncryptFile(@"D:\LinksFieldMeu\Telecall_OP&TK.txt", @"D:\LinksFieldMeu\Cripitografado.pgp", aChaves, true, true);
                //pgp.EncryptFileAndSign(@"D:\LinksFieldMeu\Telecall_OP&TK.txt", @"D:\LinksFieldMeu\Cripitografado2.pgp", aChaves, @"D:\copia\9E0F5632E05C7228F9256899D5085A8ABE69EFB4.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");
                //pgp.EncryptFileAndSign(@"D:\SIM Card\LF00001.txt", @"D:\SIM Card\LF00001.pgp", aChaves, @"D:\copia\9E0F5632E05C7228F9256899D5085A8ABE69EFB4.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");
                //pgp.EncryptFileAndSign(@"D:\SIM Card\LF00002.txt", @"D:\SIM Card\LF00002.pgp", aChaves, @"D:\copia\9E0F5632E05C7228F9256899D5085A8ABE69EFB4.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");

                //pgp.EncryptFileAndSign(@"D:\LinksField\SIM Card\Alvo.out", @"D:\Out.pgp", aChaves, @"D:\Telecall Keys\9E0F5632E05C7228F9256899D5085A8ABE69EFB4.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");
                pgp.EncryptFileAndSign(@".\in.INP", @".\out.pgp", aChaves, @".\TCK.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");
            }

        }
    }
}
