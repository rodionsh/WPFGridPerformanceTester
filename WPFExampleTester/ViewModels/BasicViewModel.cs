using System;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;
using WPFExampleTester.Models;
using System.Windows.Forms;
using System.Windows.Threading;
using WPFExampleTester.Commands;

namespace WPFExampleTester.ViewModels
{
    public class BasicViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Constants
        private const int LEVELS = 50;
        private const int UPDATES = 20;
        #endregion

        #region Views
        private ICollectionView _sortedBookView = null;

        /// <summary>
        /// BookView Collection
        /// </summary>
        public ICollectionView SortedBookView
        {
            get
            {
                if (_sortedBookView == null)
                {
                    _sortedBookView = CollectionViewSource.GetDefaultView(BookView);
                    //_sortedBookView.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Descending));
                    //ICollectionViewLiveShaping liveShapingView = (ICollectionViewLiveShaping)_sortedBookView;
                    //liveShapingView.IsLiveSorting = true;
                }
                return _sortedBookView;
            }
        }
        #endregion

        #region Properties
        bool isUpdatesLocked;
        public bool IsUpdatesLocked
        {
            get { return isUpdatesLocked; }
            set
            {
                if (isUpdatesLocked == value) return;
                isUpdatesLocked = value;
                RaisePropertyChanged("IsUpdatesLocked");
            }
        }

        private ObservableCollection<BookLine> _bookView;
        public ObservableCollection<BookLine> BookView
        {
            get
            {
                if (_bookView == null)
                {
                    _bookView = new ObservableCollection<BookLine>();
                }
                return _bookView;
            }
        }

        private string frequency;

        public string Frequency
        {
            get
            {
                if (frequency == null)
                {
                    frequency = string.Empty;
                }
                return frequency;
            }
            set
            {
                if (frequency != value)
                {
                    frequency = value;
                    RaisePropertyChanged(nameof(Frequency));
                }
            }
        }
        #endregion

        #region Commands & Events
        public BasicDelegateCommand Randomize { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Privates
        Random random;

        Timer timer;

        private DateTime lastUpdate;
        private int generated;
        #endregion

        #region Initialization
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BasicViewModel()
        {
            random = new Random();
            timer = new Timer();
            timer.Interval = UPDATES;
            timer.Tick += NextRandomSequence;
            Randomize = new BasicDelegateCommand(StartRandomizer);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Start the Randomizer
        /// </summary>
        private void StartRandomizer()
        {
            timer.Start();
        }

        /// <summary>
        /// Generate a new sequence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextRandomSequence(object sender, EventArgs e)
        {
            IsUpdatesLocked = true;

            var uiContext = System.Threading.SynchronizationContext.Current;
            //uiContext.Send(x => BookView.Clear(), null);

            for (int index = 0; index < LEVELS; index++)
            {
                int sequence = random.Next(999);
                if (BookView.Count <= index)
                {
                //    BookView.Add(new BookLine
                //    {
                //        BWork = random.Next(999),
                //        Bids = random.Next(50, 1000),
                //        Price = random.Next(40000, 90000),
                //        Asks = random.Next(50, 1000),
                //        AWork = random.Next(999)
                //    });
                uiContext.Send(x => BookView.Add(new BookLine { BWork = random.Next(999), Bids = random.Next(50, 1000), Price = random.Next(40000, 90000), Asks = random.Next(50, 1000), AWork = random.Next(999) }), null);
                }
                else
                {
                    //BookView[index] = (new BookLine
                    //{
                    //    BWork = random.Next(999),
                    //    Bids = random.Next(50, 1000),
                    //    Price = random.Next(40000, 90000),
                    //    Asks = random.Next(50, 1000),
                    //    AWork = random.Next(999)
                    //});
                    uiContext.Send(x => BookView[index] = (new BookLine { BWork = random.Next(999), Bids = random.Next(50, 1000), Price = random.Next(40000, 90000), Asks = random.Next(50, 1000), AWork = random.Next(999) }), null);
                }
            }
            var timeDif = DateTime.Now - lastUpdate;
            if (timeDif.TotalSeconds > 1)
            {
                Frequency = $"{generated / timeDif.TotalSeconds:F2} updates/second";
                generated = 0;
                lastUpdate = DateTime.Now;
            }
            generated++;
            IsUpdatesLocked = false;
        }

        /// <summary>
        /// Notify Listeners
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Dispose of the resources
        /// </summary>
        public void Dispose()
        {
            timer.Stop();
            timer.Tick -= NextRandomSequence;
            timer = null;

            random = null;
        }
        #endregion
    }
}