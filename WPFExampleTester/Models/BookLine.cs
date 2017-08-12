using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFExampleTester.Models
{
    public class BookLine
    {
        public int BWork { get; set; }
        public int Bids { get; set; }
        public double Price { get; set; }
        public int Asks { get; set; }
        public int AWork { get; set; }
    }

    public class BookLineObservable : INotifyPropertyChanged
    {
        private int bWork;
        private int bids;
        private double price;
        private int asks;
        private int aWork;

        public int BWork
        {
            get { return bWork; }
            set
            {
                bWork = value;
                OnPropertyChanged();
            }
        }

        public int Bids
        {
            get { return bids; }
            set
            {
                bids = value;
                OnPropertyChanged();
            }
        }

        public double Price
        {
            get
            {
                return price;
                OnPropertyChanged();
            }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }

        public int Asks
        {
            get { return asks; }
            set
            {
                asks = value;
                OnPropertyChanged();
            }
        }

        public int AWork
        {
            get { return aWork; }
            set
            {
                aWork = value;
                OnPropertyChanged();
            }
        }

        public static BookLineObservable Generate(Random random)
        {
            return new BookLineObservable
            {
                BWork = random.Next(999),
                Bids = random.Next(50, 1000),
                Price = random.Next(40000, 90000),
                Asks = random.Next(50, 1000),
                AWork = random.Next(999)
            };
        }

        public void Update(Random random)
        {
            BWork = random.Next(999);
            Bids = random.Next(50, 1000);
            Price = random.Next(40000, 90000);
            Asks = random.Next(50, 1000);
            AWork = random.Next(999);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class BookLineComparer : IComparer<BookLine>
    {
        private bool descencing;
        public BookLineComparer(bool descending)
        {
            this.descencing = descending;
        }

        public int Compare(BookLine x, BookLine y)
        {
            if (x.Price > y.Price)
                return descencing ? -1 : 1;
            else if (x.Price < y.Price)
                return descencing ? 1 : -1;
            else
                return 0;
        }
    }
}
