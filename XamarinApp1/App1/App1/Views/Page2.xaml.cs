using App1.Models;
using App1.ViewModels;
using App1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    public partial class Page2 : ContentPage
    {
        private Stopwatch _stopWatch;
        private Stopwatch _stopWatchTotal;

        private string pageInitializeComponentTime;
        private string pageCreateviewModelTime;

        private string pageBindingViewModelTime;
        ItemsViewModel _viewModel;

        public Page2()
        {
            _stopWatchTotal = Stopwatch.StartNew(); // Start timing
            _stopWatch = Stopwatch.StartNew(); // Start timing
            InitializeComponent();
            _stopWatch.Stop();
            pageInitializeComponentTime = $"Page InitializeComponent: {_stopWatch.ElapsedMilliseconds} ms";
            _stopWatch.Restart();
            _viewModel = new ItemsViewModel();
            _stopWatch.Stop();
            pageCreateviewModelTime = $"Page ViewModel1 creation: {_stopWatch.ElapsedMilliseconds} ms";
            _stopWatch.Restart();
            BindingContext = _viewModel;
            _stopWatch.Stop();
            pageBindingViewModelTime = $"Page ViewModel1 binding: {_stopWatch.ElapsedMilliseconds} ms";
            _stopWatch.Restart();

            _viewModel.PageInitializeComponentTime = pageInitializeComponentTime;
            _viewModel.PageCreateViewModelTime = pageCreateviewModelTime;
            _viewModel.PageBindingViewModelTime = pageBindingViewModelTime;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Give the UI time to render before stopping the stopwatch
            await Task.Delay(50); // Optional but helps with accuracy

            _stopWatch.Stop();
            _stopWatchTotal.Stop();

            _viewModel.PageOnAppearingTime = $"Page OnAppearing time: {_stopWatch.ElapsedMilliseconds} ms";
            _viewModel.PageOnAppearingTotalTime = $"Page OnAppearing total time: {_stopWatchTotal.ElapsedMilliseconds} ms";
        }
    }
}