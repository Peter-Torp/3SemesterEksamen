using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WPF.Model;


namespace Auction_House_WPF.ViewModels
{
    public class ShellViewModel : Conductor<object> //Everything can go into the Conductor
    {

        private string _firstName = "Peter"; //Add text here in a string and it will be shown 
        private string _lastName = "Torp";
        private BindableCollection<UserShowModel> _people = new BindableCollection<UserShowModel>();
        private UserShowModel _selectedPerson;

        public ShellViewModel()
        {
            // People.Add(new PersonModel { FirstName = "Peter", LastName = "Magnus1" });
            // People.Add(new PersonModel { FirstName = "Magnus", LastName = "Magnus2" });
            // People.Add(new PersonModel { FirstName = "Christian", LastName = "Magnus3" });
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName); //CopyPaste this where a value changes? - Listens to if something changes
                NotifyOfPropertyChange(() => FullName);
            }
        }


        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }


        public string FullName
        {
            get { return $" { FirstName } { LastName }"; }
        }

        public BindableCollection<UserShowModel> People //Is a list but Bindablecollection is for mvvm and is better

        {
            get { return _people; }
            set { _people = value; }
        }

        public UserShowModel SelectedPerson
        {
            get { return _selectedPerson; }

            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName) //=> !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName); - Is a lambda
        {
            //return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
            if (String.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }

    }
}