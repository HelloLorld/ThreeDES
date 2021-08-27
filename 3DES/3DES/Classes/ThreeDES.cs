namespace _3DES.Classes
{
    class ThreeDES
    {
        private DES des = new DES();
        public ThreeDES() { }
        public string Encrypt(string msg, string k1, string k2, string k3)
        {
            msg = des.Encrypt(msg, k1);
            msg = des.Decrypt(msg, k2);
            return des.Encrypt(msg, k3);
        }

        public string Decrypt(string msg, string k1, string k2, string k3)
        {
            msg = des.Decrypt(msg, k3);
            msg = des.Encrypt(msg, k2);
            msg = des.Decrypt(msg, k1);
            int k = msg.IndexOf((char)181);
            return msg.Substring(0, msg.IndexOf((char)181));
        }
    }
}
