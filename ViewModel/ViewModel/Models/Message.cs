namespace ViewModel.Models{
    public class Message{
        public string message = "Shapopi!";
        public string getMessage(){
            return message;
        }
        public void setMessage(string mess){
            this.message = mess;
        }
    }
}