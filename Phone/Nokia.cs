namespace Phone{
    public class Nokia : Phone, IRingable 
    {
        //public string versionNumber;
    public Nokia(string versionNumber, int batteryPercentage, string carrier, string ringTone) 
        : base(versionNumber, batteryPercentage, carrier, ringTone) {
            //public string versionNumber;
        }
        public string Ring() 
        {
            return getRingTone();
        }
        public string Unlock() 
        {
            return "Nokia " + getVersionNum() + "unlocked with fingerprint";
        }
        public override void DisplayInfo() 
        {
            System.Console.WriteLine("$$$$$$$$$\nNokia: "+getVersionNum()+
            "\nBattery Percentage: "+getBattery()+
            "\nCarrier: "+getCarrier()+
            "\nRing Tone: "+getRingTone()+
            "\n$$$$$$$$");         
        }
    }

}