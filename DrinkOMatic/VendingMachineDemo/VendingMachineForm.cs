using System;
using System.Windows.Forms;
using DrinksLibFramework.BusinessLogic;
using DrinksLibFramework.BusinessLogic.Factories;
using DrinksLibFramework.Helpers;
using DrinksLibFramework.Models;

namespace VendingMachineDemo
{
    public partial class VendingMachineForm : Form
    {
        private VendingMachine _vendingMachine;

        public VendingMachineForm() => InitializeComponent();

        private void VendingMachine_Load(object sender, EventArgs e)
        {
            var vendingMachineInfo = new VendingMachineInfo();
            var drinksFactory = new DrinksFactory();
            var drinksProcessor = new DrinksProcessor(drinksFactory);
            _vendingMachine = new VendingMachine(vendingMachineInfo, drinksProcessor);

            VendingMachine.DrinkOutOfStock += OnOutOfStock;
            VendingMachine.NotEnoughMoney += OnNotEnoughMoney;
            DrinksProcessor.DrinkFinishedProcessing += OnDrinkFinishedProcessing;
            Drink.ComponentAdded += DrinkOnComponentAdded;
            Drink.ProcessCompleted += DrinkOnProcessCompleted;
        }

        private void CoffeeButton_Click(object sender, EventArgs e) => _vendingMachine.DrinkButtonPressed(0);

        private void LemonTeaButton_Click(object sender, EventArgs e) => _vendingMachine.DrinkButtonPressed(1);

        private void HotChocolateButton_Click(object sender, EventArgs e) => _vendingMachine.DrinkButtonPressed(2);

        private void CancelButton_Click(object sender, EventArgs e) => _vendingMachine.CancelButtonPressed();

        private void RefundButton_Click(object sender, EventArgs e) => _vendingMachine.RefundButtonPressed();

        private void InsertOnePoundButton_Click(object sender, EventArgs e) => _vendingMachine.InsertMoney(1.00m);

        private void InsertFiftyPenceButton_Click(object sender, EventArgs e) => _vendingMachine.InsertMoney(0.50m);

        private void InsertTwentyPenceButton_Click(object sender, EventArgs e) => _vendingMachine.InsertMoney(0.20m);

        private void UpdateDisplay(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                    UpdateDisplay(message);
                }));
                return;
            }

            DisplayTextBox.Text = message;
            MoneyInsertedTextBox.Text = _vendingMachine.MoneyInserted.ToString("C");
        }

        private void UpdateLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                    UpdateLog(message);
                }));
                return;
            }

            LogRTB.AppendText($"{message}\n");;
        }

        private void DrinkOnComponentAdded(object sender, Events.ComponentAddedEventArgs e)
        {
            var componentNames = DrinksHelper.GetComponentNames(e.Component);

            foreach(var componentName in componentNames)
                UpdateLog($"Component added: {componentName}");
        }

        private void DrinkOnProcessCompleted(object sender, Events.ProcessCompletedEventArgs e)
        {
            var processNames = DrinksHelper.GetProcessNames(e.Process);

            foreach (var processName in processNames)
                UpdateLog($"Process completed: {processName}");
        }

        private void OnOutOfStock(object sender, Events.DrinkOutOfStockEventArgs e)
        {
            var message = string.Format(Constants.OutOfStock, Enum.GetName(typeof(DrinkType), e.DrinkType));
            UpdateDisplay(message);
        }

        private void OnNotEnoughMoney(object sender, Events.NotEnoughMoneyEventArgs e)
        {
            var message = string.Format(Constants.NotEnoughMoney, e.AdditionalMoneyRequired);
            UpdateDisplay(message);
        }

        private void OnDrinkFinishedProcessing(object sender, Events.DrinkFinishedProcessingEventArgs e)
        {
            UpdateLog($"Cup contains: {e.Cup.Drink.Name}");
            UpdateLog(string.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _vendingMachine.Update();

            var displayMessage = _vendingMachine.GetDisplayMessage();

            if (!string.IsNullOrEmpty(displayMessage))
                UpdateDisplay(displayMessage);
        }
    }
}
