    namespace Phone{
    public class Galaxy : Phone, IRingable {
        public Galaxy(string versionNumber, int batteryPercentage, string carrier, string ringTone) 
        : base(versionNumber, batteryPercentage, carrier, ringTone) {}
        public string Ring() 
        {
            return getRingTone();
        }

        public string Unlock() 
        {
            return "Galaxy "+getVersionNum()+" unlocked with fingerprint.";
        }
        public override void DisplayInfo() 
        {
            System.Console.WriteLine("#########\nGalaxy "+getVersionNum()+
            "\nBattery Percentage: "+getBattery()+
            "\nCarrier: "+getCarrier()+
            "\nRing Tone: "+getRingTone()+
            "\n#########");          
        }
    }
           
}