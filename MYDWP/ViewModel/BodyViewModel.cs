using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYDWP.Cards;
using MYDWP.Models;

namespace MYDWP.ViewModel
{
    internal class BodyViewModel : ViewModelBase
    {

        Dictionary<DateTime, string> events = new Dictionary<DateTime, string>
        {
            [new DateTime(2025, 5, 27)] = "Your Event",
            [new DateTime(2025, 6, 5)] = "Another Event"
        };

        public List<SubCardModel> CardList { get; set; }

        public BodyViewModel()
        {
            CardList = new List<SubCardModel>
            {
                new SubCardModel { Title = "Leave", AppliedCount = 10, PendingText = "Pending 1" },
                new SubCardModel { Title = "Travel", AppliedCount = 1, PendingText= "Pending 2" },
                new SubCardModel { Title = "Card 3", AppliedCount = 10, PendingText = "Description for Card 3" },
                new SubCardModel { Title = "Card 3", AppliedCount = 10, PendingText = "Description for Card 3" }
            };
        }
    }
}
