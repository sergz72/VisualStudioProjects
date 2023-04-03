using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace drillironc
{
  /// <summary>
  /// Interaction logic for HeaterControl.xaml
  /// </summary>
  public partial class HeaterControl : UserControl, ICommandHandler
  {
    enum Modes { NORMAL, LOW_TEMP_CHANGE, HIGH_TEMP_CHANGE }

    public int HeaterID {
      get { return selectedProfile == null ? 0 : selectedProfile.heaterID; }
      set {
        App app = Application.Current as App;
        if (app == null || app.heaterProfiles == null)
          return;
        profiles = app.heaterProfiles[value - 1];
        selectedProfile = null;
        cbTitle.Items.Clear();
        foreach (HeaterProfile profile in profiles)
        {
          ComboBoxItem cbi = new ComboBoxItem();
          cbi.Content = profile.title;
          cbi.Tag = profile;
          cbTitle.Items.Add(cbi);
          if (selectedProfile == null)
            selectedProfile = profile;
        }
        if (selectedProfile != null)
          cbTitle.SelectedIndex = 0;
        bnON.IsEnabled = selectedProfile != null;
        updateActiveTempButtons();
      }
    }
    private List<HeaterProfile> profiles;
    private HeaterProfile selectedProfile;
    private Button activeTempLowButton, activeTempHighButton;
    private Modes mode;
    private Brush savedBrush;
    private bool button_pressed;

    public HeaterControl()
    {
      InitializeComponent();
      selectedProfile = null;
      mode = Modes.NORMAL;
      button_pressed = false;
    }

    private void ButtonON_Click(object sender, RoutedEventArgs e)
    {
      ON();
    }

    private void ButtonOFF_Click(object sender, RoutedEventArgs e)
    {
      OFF();
    }

    private void ButtonT_Click(object sender, RoutedEventArgs e)
    {
      double lo_temp, hi_temp;
      Button b;

      switch (mode)
      {
        case Modes.NORMAL:
          if (activeTempHighButton == null)
          {
            b = (Button)sender;
            lo_temp = double.Parse(b.Content.ToString());
            activeTempLowButton.FontWeight = FontWeights.Normal;
            activeTempLowButton.Foreground = Brushes.Black;
            b.FontWeight = FontWeights.Bold;
            b.Foreground = Brushes.Blue;
            if (tbTemp.Text != "OFF")
              setLowTemp(lo_temp);
            if (selectedProfile != null)
              selectedProfile.default_temperature_low = (int)lo_temp;
            activeTempLowButton = b;
            break;
          }
          if (sender == activeTempLowButton)
          {
            savedBrush = activeTempLowButton.Foreground;
            activeTempLowButton.Foreground = Brushes.Yellow;
            mode = Modes.LOW_TEMP_CHANGE;
          }
          else if (sender == activeTempHighButton)
          {
            savedBrush = activeTempHighButton.Foreground;
            activeTempHighButton.Foreground = Brushes.Yellow;
            mode = Modes.HIGH_TEMP_CHANGE;
          }
          break;
        case Modes.LOW_TEMP_CHANGE:
          mode = Modes.NORMAL;
          b = (Button)sender;
          activeTempLowButton.Foreground = savedBrush;
          lo_temp = double.Parse(b.Content.ToString());
          if (activeTempHighButton != null)
          {
            hi_temp = double.Parse(activeTempHighButton.Content.ToString());
            if (lo_temp >= hi_temp)
              break;
          }
          activeTempLowButton.FontWeight = FontWeights.Normal;
          activeTempLowButton.Foreground = Brushes.Black;
          b.FontWeight = FontWeights.Bold;
          b.Foreground = Brushes.Blue;
          if (tbTemp.Text != "OFF")
            setLowTemp(lo_temp);
          if (selectedProfile != null)
            selectedProfile.default_temperature_low = (int)lo_temp;
          activeTempLowButton = b;
          break;
        case Modes.HIGH_TEMP_CHANGE:
          mode = Modes.NORMAL;
          b = (Button)sender;
          activeTempHighButton.Foreground = savedBrush;
          hi_temp = double.Parse(b.Content.ToString());
          lo_temp = double.Parse(activeTempLowButton.Content.ToString());
          if (lo_temp >= hi_temp)
            break;
          activeTempHighButton.FontWeight = FontWeights.Normal;
          activeTempHighButton.Foreground = Brushes.Black;
          b.FontWeight = FontWeights.Bold;
          b.Foreground = Brushes.Red;
          if (tbTemp.Text != "OFF")
            setHighTemp(lo_temp);
          if (selectedProfile != null)
            selectedProfile.default_temperature_high = (int)hi_temp;
          activeTempHighButton = b;
          break;
      }
    }

    private void ON()
    {
      setLowTemp(double.Parse(activeTempLowButton.Content.ToString()));
      if (activeTempHighButton != null)
        setHighTemp(double.Parse(activeTempHighButton.Content.ToString()));
    }

    public void OFF()
    {
      App app = (App)Application.Current;
      if (app.nextCommands != null)
        app.nextCommands.Enqueue(new DeviceCommand("h" + HeaterID + "0000", this));
      tbTemp.Text = "OFF";
    }

    private void setLowTemp(double value)
    {
      if (activeTempHighButton == null || !button_pressed)
      {
        App app = (App)Application.Current;
        int code = selectedProfile.calculateCode(value);
        string v = code.ToString("D4");
        lbCode.Content = v;
        app.nextCommands.Enqueue(new DeviceCommand("h" + HeaterID + v, this));
        tbTemp.Text = value.ToString();
      }
    }

    private void setHighTemp(double value)
    {
      if (activeTempHighButton != null && button_pressed)
      {
        App app = (App)Application.Current;
        int code = selectedProfile.calculateCode(value);
        string v = code.ToString("D4");
        lbCode.Content = v;
        app.nextCommands.Enqueue(new DeviceCommand("h" + HeaterID + v, this));
        tbTemp.Text = value.ToString();
      }
    }

    private delegate void updateValueProc(string value, bool button_pressed);
    public void updateStatus(string status, bool button_pressed)
    {
      lbStatus.Dispatcher.BeginInvoke(new updateValueProc(updateValue), status, button_pressed);
    }

    private void updateValue(string value, bool button_pressed)
    {
      lbStatus.Content = value;
      if (this.button_pressed != button_pressed && tbTemp.Text != "OFF")
      {
        this.button_pressed = button_pressed;
        ON();
      }
      else
        this.button_pressed = button_pressed;

      switch (mode)
      {
        case Modes.LOW_TEMP_CHANGE:
          if (activeTempLowButton.Foreground == savedBrush)
            activeTempLowButton.Foreground = Brushes.Yellow;
          else
            activeTempLowButton.Foreground = savedBrush;
          break;
        case Modes.HIGH_TEMP_CHANGE:
          if (activeTempHighButton.Foreground == savedBrush)
            activeTempHighButton.Foreground = Brushes.Yellow;
          else
            activeTempHighButton.Foreground = savedBrush;
          break;
      }
    }

    public void processCloseEvent()
    {
      OFF();
    }

    public bool CheckAnswer(string command, string answer)
    {
      return answer == "K";
    }

    private void updateActiveTempButtons()
    {
      if (activeTempLowButton != null)
      {
        activeTempLowButton.FontWeight = FontWeights.Normal;
        activeTempLowButton.Foreground = Brushes.Black;
      }
      activeTempLowButton = updateActiveTempButton(selectedProfile == null ? 0 : selectedProfile.default_temperature_low);
      activeTempLowButton.Foreground = Brushes.Blue;
      if (activeTempHighButton != null)
      {
        activeTempHighButton.FontWeight = FontWeights.Normal;
        activeTempHighButton.Foreground = Brushes.Black;
      }
      if (selectedProfile == null || selectedProfile.default_temperature_high < 0)
        activeTempHighButton = null;
      else
      {
        activeTempHighButton = updateActiveTempButton(selectedProfile.default_temperature_high);
        activeTempHighButton.Foreground = Brushes.Red;
      }
    }

    private Button updateActiveTempButton(int default_temperature)
    {
      Button activeTempButton;

      switch (default_temperature)
      {
        case 150: activeTempButton = bn150; break;
        case 160: activeTempButton = bn160; break;
        case 170: activeTempButton = bn170; break;
        case 180: activeTempButton = bn180; break;
        case 190: activeTempButton = bn190; break;
        case 200: activeTempButton = bn200; break;
        case 210: activeTempButton = bn210; break;
        case 220: activeTempButton = bn220; break;
        case 230: activeTempButton = bn230; break;
        case 240: activeTempButton = bn240; break;
        case 250: activeTempButton = bn250; break;
        case 260: activeTempButton = bn260; break;
        case 270: activeTempButton = bn270; break;
        case 280: activeTempButton = bn280; break;
        case 290: activeTempButton = bn290; break;
        case 300: activeTempButton = bn300; break;
        case 310: activeTempButton = bn310; break;
        case 320: activeTempButton = bn320; break;
        case 330: activeTempButton = bn330; break;
        case 340: activeTempButton = bn340; break;
        case 350: activeTempButton = bn350; break;
        case 360: activeTempButton = bn360; break;
        case 370: activeTempButton = bn370; break;
        case 380: activeTempButton = bn380; break;
        case 390: activeTempButton = bn390; break;
        case 400: activeTempButton = bn400; break;
        default: activeTempButton = bn150; break;
      }
      activeTempButton.FontWeight = FontWeights.Bold;
      return activeTempButton;
    }

    public void loadSettings(Dictionary<string, string> settings)
    {
      int idx = 0;
      foreach (HeaterProfile profile in profiles)
      {
        string key = "profile" + profile.ID + ".default_temp_low";
        if (settings.ContainsKey(key))
          profile.default_temperature_low = int.Parse(settings[key]);
        key = "profile" + profile.ID + ".default_temp_high";
        if (settings.ContainsKey(key))
          profile.default_temperature_high = int.Parse(settings[key]);
        if (profile.default_temperature_high > 0 && profile.default_temperature_high <= profile.default_temperature_low)
          profile.default_temperature_high = profile.default_temperature_low + 10;
        key = "profile" + profile.ID + ".selected";
        if (settings.ContainsKey(key))
          cbTitle.SelectedIndex = idx;
        idx++;
      }
      updateActiveTempButtons();
    }

    public void saveSettings(Dictionary<string, string> settings)
    {
      foreach (HeaterProfile profile in profiles)
      {
        string key = "profile" + profile.ID + ".default_temp_low";
        settings.Add(key, profile.default_temperature_low.ToString());
        key = "profile" + profile.ID + ".default_temp_high";
        settings.Add(key, profile.default_temperature_high.ToString());
        if (selectedProfile == profile)
        {
          key = "profile" + profile.ID + ".selected";
          settings.Add(key, "true");
        }
      }
    }

    private void cbTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (tbTemp.Text != "OFF")
        OFF();
      selectedProfile = cbTitle.SelectedItem == null ? null : (HeaterProfile)((ComboBoxItem)cbTitle.SelectedItem).Tag;
      bnON.IsEnabled = selectedProfile != null;
      updateActiveTempButtons();
    }
  }
}
