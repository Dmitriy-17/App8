using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Service;
using Android.Content.PM;
using Android.Graphics;

namespace App8
{
    [Activity(Theme = "@android:style/Theme.NoTitleBar")]

    public class StartGame : Activity
    {
        Helperlanguage helperlanguage;

        private NumberPicker _picker1;
        private Button _buttonSetBet;
        private Button _buttonContinue;
        private Button _buttonGetCard;
        private Button _buttonShowCard;
        private Button _buttonDoubleBet;

        private TextView _textBet;
        private TextView _textBalance;
        private TextView _playerCoins;
        private TextView _info;
        private TextView _dillerCoins;

        private TextView _playerCard1;
        private TextView _playerCard2;
        private TextView _playerCard3;
        private TextView _playerCard4;
        private TextView _playerCard5;
        private TextView _playerCard6;

        private TextView _dillerCard1;
        private TextView _dillerCard2;
        private TextView _dillerCard3;
        private TextView _dillerCard4;
        private TextView _dillerCard5;
        private TextView _dillerCard6;

        TextView editBet;

        private List<TextView> _listCardsPlayer = new List<TextView>();
        private List<TextView> _listCardsDiller = new List<TextView>();

        private static View _clubs;
        private static View _diamonds;
        private static View _hearts;
        private static View _spades;
        private Dictionary<Suit, int> _dictionarySuit;

        private GameManager _gameManager;
        private GameInformation _gameInformation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            if (savedInstanceState == null)
            {
                savedInstanceState = new Bundle();
            }

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.StartGame);

            var language = Intent.GetStringArrayListExtra("settings");
            helperlanguage = new Helperlanguage(language[0], this);

            this.RequestedOrientation = ScreenOrientation.Portrait;

            _gameManager = new GameManager();

            _buttonSetBet = FindViewById<Button>(Resource.Id.buttonSetBet);
            _buttonShowCard = FindViewById<Button>(Resource.Id.buttonShowCard);
            _buttonGetCard = FindViewById<Button>(Resource.Id.buttonGetCard);
            _buttonDoubleBet = FindViewById<Button>(Resource.Id.buttonDoubleBet);
            _buttonContinue = FindViewById<Button>(Resource.Id.buttonContinue);

            _buttonSetBet.Text = helperlanguage.SetBet;
            _buttonShowCard.Text = helperlanguage.Stand;
            _buttonGetCard.Text = helperlanguage.GetCard;
            _buttonDoubleBet.Text = helperlanguage.DoubleBet;
            _buttonContinue.Text = helperlanguage.Continue;


            editBet = FindViewById<EditText>(Resource.Id.editText1);

            _playerCard1 = FindViewById<TextView>(Resource.Id.cardplayer1);
            _playerCard2 = FindViewById<TextView>(Resource.Id.cardplayer2);
            _playerCard3 = FindViewById<TextView>(Resource.Id.cardplayer3);
            _playerCard4 = FindViewById<TextView>(Resource.Id.cardplayer4);
            _playerCard5 = FindViewById<TextView>(Resource.Id.cardplayer5);
            _playerCard6 = FindViewById<TextView>(Resource.Id.cardplayer6);
            _dillerCard1 = FindViewById<TextView>(Resource.Id.carddiller1);
            _dillerCard2 = FindViewById<TextView>(Resource.Id.carddiller2);
            _dillerCard3 = FindViewById<TextView>(Resource.Id.carddiller3);
            _dillerCard4 = FindViewById<TextView>(Resource.Id.carddiller4);
            _dillerCard5 = FindViewById<TextView>(Resource.Id.carddiller5);
            _dillerCard6 = FindViewById<TextView>(Resource.Id.carddiller6);
            
            _listCardsPlayer.Add(_playerCard1);
            _listCardsPlayer.Add(_playerCard2);
            _listCardsPlayer.Add(_playerCard3);
            _listCardsPlayer.Add(_playerCard4);
            _listCardsPlayer.Add(_playerCard5);
            _listCardsPlayer.Add(_playerCard6);
            _listCardsDiller.Add(_dillerCard1);
            _listCardsDiller.Add(_dillerCard2);
            _listCardsDiller.Add(_dillerCard3);
            _listCardsDiller.Add(_dillerCard4);
            _listCardsDiller.Add(_dillerCard5);
            _listCardsDiller.Add(_dillerCard6);

            _dillerCoins = FindViewById<TextView>(Resource.Id.dillerCoins);
            _textBet = FindViewById<TextView>(Resource.Id.bet);
            _textBalance = FindViewById<TextView>(Resource.Id.balance);
            _playerCoins = FindViewById<TextView>(Resource.Id.playerCoins);
            _info = FindViewById<TextView>(Resource.Id.info);

            _clubs = FindViewById<View>(Resource.Drawable.clubs);
            _diamonds = FindViewById<View>(Resource.Drawable.diamonds);
            _hearts = FindViewById<View>(Resource.Drawable.hearts);
            _spades = FindViewById<View>(Resource.Drawable.spades);

            _dictionarySuit = new Dictionary<Suit, int>
          {
            {Suit.Club,  Resource.Drawable.clubs},
            {Suit.Diamond,  Resource.Drawable.diamonds},
            {Suit.Heart,  Resource.Drawable.hearts},
            {Suit.Spade,  Resource.Drawable.spades}
          };

   

            start();

            _buttonGetCard.Click += GetCard;
            _buttonContinue.Click += ContinueGame;
            _buttonShowCard.Click += ShowCsrd;
            _buttonDoubleBet.Click += DoubleDown;
            _buttonSetBet.Click += SetBet;           
        }

        #region ActionMethods
        private void start()
        {
            IsVisibleButtons(StatusGame.StartGame);
            _gameInformation = _gameManager.GetGameInformation(CommandtGame.StartGame);
            _textBalance.Text = (helperlanguage.Balance + Convert.ToString(_gameInformation.Player.Balance));
        }
        private void SetBet(object sender, EventArgs e)
        {

            _picker1 = new NumberPicker(this);
            var maxBet = _gameManager.MaxBet();

            editBet = new EditText(this);

            editBet.SetRawInputType( Android.Text.InputTypes.ClassNumber);

            AlertDialog.Builder builder = new AlertDialog.Builder(this).SetView(editBet);
            builder.SetTitle(helperlanguage.SetBet);
            builder.SetNegativeButton(helperlanguage.Cancel, (s, a) => { });
            builder.SetPositiveButton(helperlanguage.Ok, (s, a) =>
            { var inputValue = Convert.ToInt32(editBet.Text);
                bool IsVallid =  inputValue <= maxBet ? true : false;
                if(IsVallid)
                {
                    play(inputValue);
                }
                else
                {
                    Toast.MakeText(this, helperlanguage.IncorrectBet, ToastLength.Short).Show();
                }
            });
            builder.Show();
        }
        
        private void play(int bet)
        {
            _gameInformation = _gameManager.GetGameInformation(CommandtGame.Deal, bet);
            _textBet.Text = (helperlanguage.Bet + Convert.ToString(_gameInformation.Player.Bet));
            _textBalance.Text = (helperlanguage.Balance + Convert.ToString(_gameInformation.Player.Balance));
            _playerCoins.Text = _gameInformation.Player.Coins.Count < 2 ? Convert.ToString(_gameInformation.Player.Coins[0]) : Convert.ToString(_gameInformation.Player.Coins[0]) + "/" + Convert.ToString(_gameInformation.Player.Coins[1]);   //("Player Coins:" + Convert.ToString(gameInformation.Player.Coins[0]));

            ShowUserCards(_gameInformation.Player.Cards);
            ShowFirstDillerCards(_gameInformation.Diller.Cards);
            IsVisibleButtons(StatusGame.Play);
        }
        private void ShowCsrd(object sender, EventArgs e)
        {
            _gameInformation = _gameManager.GetGameInformation(CommandtGame.Stand);
            IsVisibleButtons(_gameInformation.StatusGame);
            _textBet.Text = (helperlanguage.Bet + Convert.ToString(_gameInformation.Player.Bet));
            _dillerCoins.Text = _gameInformation.Diller.Coins.Count < 2 ? Convert.ToString(_gameInformation.Diller.Coins[0]) : Convert.ToString(_gameInformation.Diller.Coins[0]) + "/" + Convert.ToString(_gameInformation.Diller.Coins[1]);
            ShowDillerCards(_gameInformation.Diller.Cards);
            _textBalance.Text = (helperlanguage.Balance + Convert.ToString(_gameInformation.Player.Balance));
        }

        private void GetCard(object sender, EventArgs e)
        {
            _gameInformation = _gameManager.GetGameInformation(CommandtGame.Hit);
            _textBet.Text = (helperlanguage.Bet + Convert.ToString(_gameInformation.Player.Bet));
            _textBalance.Text = (helperlanguage.Balance + Convert.ToString(_gameInformation.Player.Balance));
            _playerCoins.Text = _gameInformation.Player.Coins.Count < 2 ? Convert.ToString(_gameInformation.Player.Coins[0]) : Convert.ToString(_gameInformation.Player.Coins[0]) + "/" + Convert.ToString(_gameInformation.Player.Coins[1]);   //("Player Coins:" + Convert.ToString(gameInformation.Player.Coins[0]));
            IsVisibleButtons(_gameInformation.StatusGame);
            ShowUserCards(_gameInformation.Player.Cards);
        }
        private void DoubleDown(object sender, EventArgs e)
        {
            _gameInformation = _gameManager.GetGameInformation(CommandtGame.DoubleDown);
            _textBet.Text = (helperlanguage.Bet + Convert.ToString(_gameInformation.Player.Bet));
            _textBalance.Text = (helperlanguage.Balance + Convert.ToString(_gameInformation.Player.Balance));
            _playerCoins.Text = _gameInformation.Player.Coins.Count < 2 ? Convert.ToString(_gameInformation.Player.Coins[0]) : Convert.ToString(_gameInformation.Player.Coins[0]) + "/" + Convert.ToString(_gameInformation.Player.Coins[1]);   //("Player Coins:" + Convert.ToString(gameInformation.Player.Coins[0]));
            IsVisibleButtons(_gameInformation.StatusGame);
            ShowUserCards(_gameInformation.Player.Cards);
        }

        private void ContinueGame(object sender, EventArgs e)
        {
            _gameInformation = _gameManager.GetGameInformation(CommandtGame.Continue);
            _textBet.Text = (helperlanguage.Bet + Convert.ToString(_gameInformation.Player.Bet));
            _textBalance.Text = (helperlanguage.Balance + Convert.ToString(_gameInformation.Player.Balance));
            _playerCoins.Text = ("");
            _dillerCoins.Text = ("");
            IsVisibleButtons(_gameInformation.StatusGame);
            InVisiblePlayerCards();
            InVisibleDillerCards();
        }
        #endregion

        #region HelpMethods
       
        private void ShowFirstDillerCards(List<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (i == 0)
                {
                    _listCardsDiller[i].SetBackgroundResource(_dictionarySuit[cards[i].SuitCard]);
                    _listCardsDiller[i].Visibility = ViewStates.Visible;
                    if (cards[i].SuitCard == Suit.Diamond || cards[i].SuitCard == Suit.Heart)
                    {
                        _listCardsDiller[i].SetTextColor(Color.ParseColor("#ffcc0000"));
                        _listCardsDiller[i].Text = TextForImageCard(cards[i]);
                    }
                    else
                    {
                        _listCardsDiller[i].SetTextColor(Color.ParseColor("#ff000000"));
                        _listCardsDiller[i].Text = TextForImageCard(cards[i]);
                    }
                }
                else
                {
                    _listCardsDiller[i].Text = "";
                    _listCardsDiller[i].Visibility = ViewStates.Visible;
                    _listCardsDiller[i].SetBackgroundResource(Resource.Drawable.mask1);
                }
            }
        }
        private string TextForImageCard(Card card)
        {
            if (card.ImageCard == ImageCard.A || card.ImageCard == ImageCard.J || card.ImageCard == ImageCard.Q || card.ImageCard == ImageCard.K)
            {
                return card.ImageCard.ToString();
            }
            var result = (int)card.ImageCard;
            return result.ToString();
        }
        private void ShowUserCards(List<Card> cards)
        {
            InVisiblePlayerCards();
            for (int i = 0; i < cards.Count; i++)
            {
                _listCardsPlayer[i].SetBackgroundResource(_dictionarySuit[cards[i].SuitCard]);
                _listCardsPlayer[i].Visibility = ViewStates.Visible;         

                if (cards[i].SuitCard == Suit.Diamond || cards[i].SuitCard == Suit.Heart)
                {
                    _listCardsPlayer[i].SetTextColor(Color.ParseColor("#ffcc0000"));
                }
                else
                {
                    _listCardsPlayer[i].SetTextColor(Color.ParseColor("#ff000000"));
                }
                _listCardsPlayer[i].Text = TextForImageCard(cards[i]);
            }
        }
        private void ShowDillerCards(List<Card> cards)
        {
            InVisibleDillerCards();
            for (int i = 0; i < cards.Count; i++)
            {
                _listCardsDiller[i].SetBackgroundResource(_dictionarySuit[cards[i].SuitCard]);
                _listCardsDiller[i].Visibility = ViewStates.Visible;
                if (cards[i].SuitCard == Suit.Diamond || cards[i].SuitCard == Suit.Heart)
                {
                    _listCardsDiller[i].SetTextColor(Color.ParseColor("#ffcc0000"));
                }
                else
                {
                    _listCardsDiller[i].SetTextColor(Color.ParseColor("#ff000000"));

                }
                _listCardsDiller[i].Text = TextForImageCard(cards[i]);
            }
        }
        private void InVisiblePlayerCards()
        {
            for (int i = 0; i < _listCardsPlayer.Count; i++)
            {
                if (_listCardsPlayer[i].Visibility == ViewStates.Visible)
                {
                    _listCardsPlayer[i].Visibility = ViewStates.Invisible;
                }
            }
        }
        private void InVisibleDillerCards()
        {
            for (int i = 0; i < _listCardsDiller.Count; i++)
            {
                if (_listCardsDiller[i].Visibility == ViewStates.Visible)
                {
                    _listCardsDiller[i].Text = "";
                    _listCardsDiller[i].Visibility = ViewStates.Invisible;
                }
            }
        }
        
        private void IsVisibleButtons(StatusGame statusGame)
        {
            if (statusGame == StatusGame.StartGame)
            {
                _buttonSetBet.Visibility = ViewStates.Visible;
                _buttonShowCard.Visibility = ViewStates.Invisible;
                _buttonGetCard.Visibility = ViewStates.Invisible;
                _buttonDoubleBet.Visibility = ViewStates.Invisible;
                _buttonContinue.Visibility = ViewStates.Invisible;
                _info.Text = "";
            }
            else if (statusGame == StatusGame.Play)
            {
                _buttonSetBet.Visibility = ViewStates.Invisible;
                _buttonShowCard.Visibility = ViewStates.Visible;
                _buttonGetCard.Visibility = ViewStates.Visible;
                _buttonDoubleBet.Visibility = ViewStates.Visible;
                _buttonContinue.Visibility = ViewStates.Invisible;
                _info.Text = "";
            }
            else if (statusGame == StatusGame.Win || statusGame == StatusGame.Losing || statusGame == StatusGame.Draw)
            {

                _buttonSetBet.Visibility = ViewStates.Invisible;
                _buttonShowCard.Visibility = ViewStates.Invisible;
                _buttonGetCard.Visibility = ViewStates.Invisible;
                _buttonDoubleBet.Visibility = ViewStates.Invisible;
                _buttonContinue.Visibility = ViewStates.Visible;
                _info.Text = statusGame.ToString();
            }
            else //Game Over
            {
                _buttonSetBet.Visibility = ViewStates.Invisible;
                _buttonShowCard.Visibility = ViewStates.Invisible;
                _buttonGetCard.Visibility = ViewStates.Invisible;
                _buttonDoubleBet.Visibility = ViewStates.Invisible;
                _buttonContinue.Visibility = ViewStates.Invisible;
                _info.Text = statusGame.ToString();
            }
        }
        #endregion
    }
}