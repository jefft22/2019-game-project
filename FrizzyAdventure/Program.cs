namespace RedRocket.FA
{
    using FrizzyAdventure.Managers.ServiceLocator;
    using System;
    using System.Windows.Forms;

    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            try
            {
                using (var frizzyGame = new FrizzyAdventureGame(new WindowsServiceLocator()))
                {
                    frizzyGame.Run();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured and the game cannot continue.\n\n{ex.GetType().Name}\n{ex.Message}", "Exception Occured", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}