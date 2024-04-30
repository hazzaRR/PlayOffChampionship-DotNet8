namespace PlayOffChampionship.Dtos
{
    public class MatchDto
    {


        public int Id { get; set; }

        public required string Player1Id { get; set; }
        public required string Player2Id { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public PlayerDto? Player1 { get; set; }
        public PlayerDto? Player2 { get; set; }
        public required string WinnerId { get; set; }
        public PlayerDto? Winner { get; set; }
        public int LeagueId { get; set; }
        public LeagueDto? League { get; set; }
        public DateTime MatchDate { get; set; }


    }
}
