using Microsoft.VisualBasic;
using MYDWP.Cards;
using MYDWP.Command;
using MYDWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MYDWP.ViewModel
{
    internal class BodyViewModel : ViewModelBase
    {
        public ObservableCollection<SubCardModel> CardList { get; set; }

        private SubCardModel _leftCard;
        private SubCardModel _midelCard;
        private SubCardModel _rightCard;

        public SubCardModel LeftCard
        {
            get => _leftCard;
            set
            {
                if (_leftCard != value)
                {
                    _leftCard = value;
                    OnPropertyChanged(nameof(LeftCard));
                }
            }
        }

        public SubCardModel MidelCard
        {
            get => _midelCard;
            set
            {
                if (_midelCard != value)
                {
                    _midelCard = value;
                    OnPropertyChanged(nameof(MidelCard));
                }
            }
        }

        public SubCardModel RightCard
        {
            get => _rightCard;
            set
            {
                if (_rightCard != value)
                {
                    _rightCard = value;
                    OnPropertyChanged(nameof(RightCard));
                }
            }
        }


        private int _selectedCardIndex = 0;
        public int SelectedCardIndex
        {
            get => _selectedCardIndex;
            set
            {
                if (_selectedCardIndex != value)
                {
                    _selectedCardIndex = value;
                    UpdateVisibleCards();

                    OnPropertyChanged(nameof(SelectedCardIndex));
                }
            }
        }

        public ICommand SlideLeftCommand => new RelayCommand(() =>
        {
            if (SelectedCardIndex > 0) SelectedCardIndex--;
        });

        public ICommand SlideRightCommand => new RelayCommand(() =>
        {
            if (SelectedCardIndex < CardList.Count - 1) SelectedCardIndex++;
        });

        public BodyViewModel()
        {
            CardList = new ObservableCollection<SubCardModel>
            {
                new SubCardModel { Title = "Leave", AppliedCount = 10, PendingText = "Pending 1" },
                new SubCardModel { Title = "Travel", AppliedCount = 1, PendingText= "Pending 2" },
                new SubCardModel { Title = "Card 3", AppliedCount = 10, PendingText = "Pending 3" },
                new SubCardModel { Title = "Card 4", AppliedCount = 10, PendingText = "Pending 4" }
            };
            MidelCard  = CardList.ElementAtOrDefault(0);
            RightCard  = CardList.ElementAtOrDefault(1);
        }

        private void UpdateVisibleCards()
        {
            // Clear all by default
            LeftCard = null;
            MidelCard = null;
            RightCard = null;

            if (CardList == null || CardList.Count == 0)
                return;

            try
            {


                var midlecard = CardList.ElementAtOrDefault(SelectedCardIndex);
                if (midlecard != null)
                    midlecard.IsMainView = true;
                MidelCard = midlecard;

                if (SelectedCardIndex > 0)
                {
                    var card = CardList.ElementAtOrDefault(SelectedCardIndex - 1);
                    card.IsMainView = false;
                    LeftCard = card;
                }
                if (SelectedCardIndex < CardList.Count - 1)
                {
                    RightCard = CardList.ElementAtOrDefault(SelectedCardIndex + 1);
                    RightCard.IsMainView = false;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
