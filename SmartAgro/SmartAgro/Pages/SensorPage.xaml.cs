
using Newtonsoft.Json;
using SmartAgro.Converters;
using SmartAgro.Models;
using SmartAgro.Services;
using SmartAgro.Utils;
using SmartAgro.ViewModels;
using SmartAgroAPI.DataTransferObjects;
using SmartAgroAPI.Models;
using Syncfusion.Maui.Charts;
using System.Collections.ObjectModel;
using System.Globalization;

namespace SmartAgro.Pages;

public partial class SensorPage : ContentPage
{
    private ApiRequestSensor _sensor;

    public SensorPage(ApiRequestSensor sensor)
	{

		InitializeComponent();
        BindingContext = this;
        _sensor = sensor;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadData();
    }

    private void LoadData()
    {
        LoadDates();
        LoadChart(null);
        LoadInfo();
    }
    public ChartViewModel chartViewModel { get; set; } = new ChartViewModel();
    public ObservableCollection<DateTime> dateTimes { get; set; } = new ObservableCollection<DateTime>();
    private void LoadDates()
    {
        dateTimes.Clear();
        datesView.ItemsSource = null;

        var dates = _sensor.SensorLogs.GroupBy(x=> x.DataAtualizacao.Value.Date).Select(x=> x.Key.Date).ToList();
        foreach (var date in dates)
        {
            dateTimes.Add(date);

        }
        datesView.ItemsSource = dateTimes;
    }

    private void LoadInfo()
    {
        dataColheita.Text = "";
        nomeBaia.Text = "";

        nomeBaia.Text = _sensor.SensorName;

        DateOnly colheita = (DateOnly)_sensor.DataColheita!;

        int estimado = (colheita.ToDateTime(TimeOnly.MinValue) - DateTime.Now).Days;

        dataColheita.Text = estimado.ToString() + " Dias";

        var vm = new SensorViewModel(_sensor, Data.SelectedDate);

        infoView.ItemsSource = vm.Sensors;

        var logs = vm.Sensors;

        foreach (var item in logs)
        {
            chartViewModel = new ChartViewModel(item.Logs!);
        }
    }

    private void TapGestureRecognizer_Tapped_Select(object sender, TappedEventArgs e)
    {
        var binding = ((Border)sender).BindingContext;

        if ((binding as DateTime?).HasValue)
        {
            Data.SelectedDate = (binding as DateTime?)!.Value;            
        }

        LoadDates();
        LoadInfo();
    }

    private void LoadChart( List<ChartModel> test)
    {
        chartXml.Series.Clear();

        chartXml.BindingContext = chartViewModel;
        //Estilo do grafico
        ChartMarkerSettings chartMarkerSettings = new ChartMarkerSettings();
        chartMarkerSettings.Type = ShapeType.Diamond;

        //Estilo do data label
        DataTemplate labelTemplate = new DataTemplate(() =>
        {
            StackLayout stackLayout = new StackLayout { Spacing = 5, Padding = 5};

            var label = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                FontSize = 18,
                TextColor = Color.FromRgb(62, 142, 74)
        };
            label.SetBinding(Label.TextProperty, "Item.Values");

            stackLayout.Children.Add(label);

            return stackLayout;
        });

        //Configuracao de series
        LineSeries series = new LineSeries();
        series.MarkerSettings = chartMarkerSettings;
        series.LabelTemplate = labelTemplate;

        Console.WriteLine(test);

        if (test != null) 
        { 
            series.ItemsSource = test[0];
            series.XBindingPath = test[0].Date.TimeOfDay.ToString();
            series.YBindingPath = test[0].Value.ToString();
        }

        chartXml.Series.Add(series);
    }

    private void TapGestureRecognizer_Tapped_back(object sender, TappedEventArgs e)
    {
        Navigation.RemovePage(this);
    }

    private void TapGestureRecognizer_Tapped_chart(object sender, TappedEventArgs e)
    {
        var binding = ((Border)sender).BindingContext as SensorInfo;

        if (binding != null) 
        {
            chartXml.BindingContext = chartViewModel = new ChartViewModel(binding.Logs);
            LoadChart(chartViewModel.DataChart);
        }
    }
}