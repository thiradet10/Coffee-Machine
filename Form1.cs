using veding_machine;
using vending_machine;

namespace CoffeeMachine
{
    public partial class Form1 : Form
    {
        MenuItem itemBlackCoffee = new MenuItem();
        MenuItem itemLatte = new MenuItem();
        MenuItem itemMocha = new MenuItem();
        MenuItem itemChocolate = new MenuItem();
        MenuItem itemWater = new MenuItem();
        MenuItem itemCoffee = new MenuItem();
        MenuItem itemMilk = new MenuItem();
        MenuItem itemChocolatMix = new MenuItem();

        public Form1()
        {
            InitializeComponent();

            itemBlackCoffee.Name = "BlackCoffee";
            itemBlackCoffee.Price = 199;
            itemBlackCoffee.Quantity = 0;
            itemBlackCoffee.Ingredients.Add("Water", 500);
            itemBlackCoffee.Ingredients.Add("Coffee", 100);

            itemLatte.Name = "Latte";
            itemLatte.Price = 159;
            itemLatte.Quantity = 0;
            itemLatte.Ingredients.Add("Water", 600);
            itemLatte.Ingredients.Add("Coffee", 120);
            itemLatte.Ingredients.Add("Milk", 50);

            itemMocha.Name = "Mocha";
            itemMocha.Price = 189;
            itemMocha.Quantity = 0;
            itemMocha.Ingredients.Add("Water", 300);
            itemMocha.Ingredients.Add("Coffee", 20);
            itemMocha.Ingredients.Add("Chocolate", 10);

            itemChocolate.Name = "Chocolate";
            itemChocolate.Price = 99;
            itemChocolate.Quantity = 0;
            itemChocolate.Ingredients.Add("Water", 500);
            itemChocolate.Ingredients.Add("Chocolate", 200);

            tbBackCoffeePrice.Text = itemBlackCoffee.Price.ToString();
            tbBlackCoffeeQuantity.Text = itemBlackCoffee.Quantity.ToString();

            tbLattePrice.Text = itemLatte.Price.ToString();
            tbLatteQuantity.Text = itemLatte.Quantity.ToString();

            tbMochaPrice.Text = itemMocha.Price.ToString();
            tbMochaQuantity.Text = itemMocha.Quantity.ToString();

            tbChocolatPrice.Text = itemChocolate.Price.ToString();
            tbChocolatQuantity.Text = itemChocolate.Quantity.ToString();

            itemWater.Name = "Water Mix";
            itemWater.Quantity = 10000;

            itemCoffee.Name = "Coffee Mix";
            itemCoffee.Quantity = 10000;

            itemMilk.Name = "Milk Mix";
            itemMilk.Quantity = 10000;

            itemChocolatMix.Name = "Chocolat Mix";
            itemChocolatMix.Quantity = 10000;

            tbWaterMix.Text = itemWater.Quantity.ToString();
            tbCoffeBeansMix.Text = itemCoffee.Quantity.ToString();
            tbMilkMix.Text = itemMilk.Quantity.ToString();
            tbChocolateMix.Text = itemChocolatMix.Quantity.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Chack_Click(object sender, EventArgs e)
        {
            try
            {
                double dCash = double.Parse(tbCrash.Text);
                double dTotal = 0;

                Dictionary<string, Ingredient> availableIngredients = new Dictionary<string, Ingredient>
                {
                    { "Water", new Ingredient("Water", 10000) },
                    { "Coffee", new Ingredient("Coffee", 10000) },
                    { "Milk", new Ingredient("Milk", 10000) },
                    { "Chocolate", new Ingredient("Chocolate", 10000) }
                };

                if (chbBlckCoffee.Checked)
                {
                    itemBlackCoffee.Quantity = int.Parse(tbBlackCoffeeQuantity.Text);
                    dTotal += itemBlackCoffee.GetTotalPrice();
                    itemBlackCoffee.UseIngredients(availableIngredients);


                    tbWaterMix.Text = availableIngredients["Water"].Quantity.ToString();
                    tbCoffeBeansMix.Text = availableIngredients["Coffee"].Quantity.ToString();
                }


                if (chbLatte.Checked)
                {
                    itemLatte.Quantity = int.Parse(tbLatteQuantity.Text);
                    dTotal += itemLatte.GetTotalPrice();
                    itemLatte.UseIngredients(availableIngredients);

                    tbWaterMix.Text = availableIngredients["Water"].Quantity.ToString();
                    tbCoffeBeansMix.Text = availableIngredients["Coffee"].Quantity.ToString();
                    tbMilkMix.Text = availableIngredients["Milk"].Quantity.ToString();
                }

                if (chbMocha.Checked)
                {
                    itemMocha.Quantity = int.Parse(tbMochaQuantity.Text);
                    dTotal += itemMocha.GetTotalPrice();
                    itemMocha.UseIngredients(availableIngredients);

                    tbWaterMix.Text = availableIngredients["Water"].Quantity.ToString();
                    tbCoffeBeansMix.Text = availableIngredients["Coffee"].Quantity.ToString();
                    tbChocolateMix.Text = availableIngredients["Chocolate"].Quantity.ToString();
                }

                if (chbChocolat.Checked)
                {
                    itemChocolate.Quantity = int.Parse(tbChocolatQuantity.Text);
                    dTotal += itemChocolate.GetTotalPrice();
                    itemChocolate.UseIngredients(availableIngredients);

                    tbWaterMix.Text = availableIngredients["Water"].Quantity.ToString();
                    tbChocolateMix.Text = availableIngredients["Chocolate"].Quantity.ToString();
                }

                if (dCash < dTotal)
                {
                    MessageBox.Show("Insufficient cash", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double dChange = dCash - dTotal;
                tbTotal.Text = dTotal.ToString("F2");
                tbChange.Text = dChange.ToString("F2");

                CalculateChangeDenominations(dChange);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please fill in the numbers correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateChangeDenominations(double change)
        {
            double[] denominations = { 1000, 500, 100, 50, 20, 10, 5, 1, 0.50, 0.25 };
            int[] changeCount = new int[denominations.Length];
            double remainChange = change;

            for (int i = 0; i < denominations.Length; i++)
            {
                changeCount[i] = (int)(remainChange / denominations[i]);
                remainChange %= denominations[i];
            }
            tb1000.Text = changeCount[0].ToString();
            tb500.Text = changeCount[1].ToString();
            tb100.Text = changeCount[2].ToString();
            tb50.Text = changeCount[3].ToString();
            tb20.Text = changeCount[4].ToString();
            tb10.Text = changeCount[5].ToString();
            tb5.Text = changeCount[6].ToString();
            tb1.Text = changeCount[7].ToString();
            tb05.Text = changeCount[8].ToString();
            tb025.Text = changeCount[9].ToString();
            
        }       
    }
}
