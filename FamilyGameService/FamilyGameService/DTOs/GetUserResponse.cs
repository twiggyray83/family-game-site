namespace FamilyGameService.DTOs
{
    public class GetUserResponse
    {
        private string playerName = "";
        private int id;
        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
