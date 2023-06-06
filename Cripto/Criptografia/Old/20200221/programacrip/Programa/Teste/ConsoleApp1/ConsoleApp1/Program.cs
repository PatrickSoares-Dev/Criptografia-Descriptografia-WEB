using PgpCore;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Encrip();
            //DEcrip();

        }

        public static void DEcrip()
        {
            using (PGP pgp = new PGP())
            {
                pgp.DecryptFile(@"D:\20200221\descrip\in\LF_BR_tellcall_ekyi_20200214.out.gpg", @"D:\20200221\descrip\out\LF_BR_tellcall_ekyi_20200214.out", @"D:\20200110\TCK.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");
            }
        }

        public static void Encrip()
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
                //string[] aChaves = new string[] { @"D:\20200110\pubkey.asc" };
                //string[] aChaves = new string[] { @"D:\Public Keys\GEMALTO\DGC_CVA_V2.asc" };
                //string[] aChaves = new string[] { @"D:\Public Keys\PARETEUM\Ramy.asc", @"D:\Public Keys\PARETEUM\Teumpub.asc", @"D:\Public Keys\PARETEUM\PTSecure.asc" };

                //string[] aChaves = new string[] { @"D:\Telecall Keys\Telecallpublic.asc" };
                //CHAVE PUBLICA CLIENTE
                //pgp.EncryptFile(@"D:\LinksFieldMeu\Telecall_OP&TK.txt", @"D:\LinksFieldMeu\Cripitografado.pgp", aChaves, true, true);
                //pgp.EncryptFileAndSign(@"D:\LinksFieldMeu\Telecall_OP&TK.txt", @"D:\LinksFieldMeu\Cripitografado2.pgp", aChaves, @"D:\copia\9E0F5632E05C7228F9256899D5085A8ABE69EFB4.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");
                //pgp.EncryptFileAndSign(@"D:\SIM Card\LF00001.txt", @"D:\SIM Card\LF00001.pgp", aChaves, @"D:\copia\9E0F5632E05C7228F9256899D5085A8ABE69EFB4.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");
                //pgp.EncryptFileAndSign(@"D:\SIM Card\LF00002.txt", @"D:\SIM Card\LF00002.pgp", aChaves, @"D:\copia\9E0F5632E05C7228F9256899D5085A8ABE69EFB4.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");

                //pgp.EncryptFileAndSign(@"D:\LinksField\SIM Card\Alvo.out", @"D:\Out.pgp", aChaves, @"D:\Telecall Keys\9E0F5632E05C7228F9256899D5085A8ABE69EFB4.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");
                //pgp.EncryptFileAndSign(@".\IN.INP", @".\OUT.pgp", aChaves, @".\TCK.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");
                //pgp.EncryptFileAndSign(@"D:\20200110\TLC12354.INP", @"D:\20200110\OUT\TLC12354.INP.pgp", aChaves, @"D:\20200110\TCK.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");
                //pgp.EncryptFileAndSign(@"D:\20200110\TLC12355.INP", @"D:\20200110\OUT\TLC12355.INP.pgp", aChaves, @"D:\20200110\TCK.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");
                //pgp.EncryptFileAndSign(@"D:\Producao\TLC12354.INP", @"D:\20200127\TLC12354.INP.pgp", aChaves, @"D:\20200110\TCK.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");

                //pgp.EncryptFileAndSign(@"C:\tmp\20200128\programacrip\out\TLC12354.ota", @"C:\tmp\20200128\programacrip\out\crip\TLC12354.ota.pgp", aChaves, @"D:\20200110\TCK.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");
                //pgp.EncryptFileAndSign(@"C:\tmp\20200128\programacrip\out\TLC12354.out", @"C:\tmp\20200128\programacrip\out\crip\TLC12354.out.pgp", aChaves, @"D:\20200110\TCK.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");

                //pgp.EncryptFileAndSign(@"C:\tmp\20200128\programacrip\out\TLC12355.ota", @"C:\tmp\20200128\programacrip\out\crip\TLC12355.ota.pgp", aChaves, @"D:\20200110\TCK.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");
                string[] aChaves = new string[] { @"D:\Public Keys\PARETEUM\Teumpub.asc", @"D:\Public Keys\PARETEUM\PTSecure.asc", @"D:\Public Keys\PARETEUM\Ramy.asc" };
            


                pgp.EncryptFileAndSign(@"D:\20200221\crip\in\LF_BR_tellcall_ekyi_20200214.out", @"D:\20200221\crip\out\LF_BR_tellcall_ekyi_20200214.out.pgp", aChaves, @"D:\20200110\TCK.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");

            }

        }
    }
}
