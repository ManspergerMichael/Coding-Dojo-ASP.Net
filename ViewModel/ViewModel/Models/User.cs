namespace ViewModel.Models{
    public class User{
        public string firstName{get;set;}
        public string lastName{get;set;}

        public User(string fName, string lName){
            firstName = fName;
            lastName = lName;
        }
    }
}