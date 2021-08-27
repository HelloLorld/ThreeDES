namespace _3DES.Classes
{
    class Message
    {
        static int msgCount = 0;
        public bool mode;
        public string key1, key2, key3, msg;
        public string encryptedMsg, decryptedMsg;
        private ThreeDES threeDES = new ThreeDES();
        public Message(string message, string k1, string k2, string k3, bool desMode)
        {
            msgCount++;
            key1 = k1; key2 = k2; key3 = k3;
            msg = message;
            mode = desMode;
            if(mode)
            encryptedMsg = threeDES.Encrypt(msg, key1, key2, key3);
            else
            decryptedMsg = threeDES.Decrypt(msg, key1, key2, key3);
        }
    }
}
