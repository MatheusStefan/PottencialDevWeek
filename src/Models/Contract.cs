namespace src.Models;

public class Contract {
    
    public Contract(){
        this.DataCriacao = DateTime.Now;
        this.Valor = 0;
        this.TokenId = "00000";
    }

    public Contract(string TokenId, double Valor){
        this.DataCriacao = DateTime.Now;
        this.TokenId = TokenId;
        this.Valor = Valor;
    }
    public DateTime DataCriacao { get; set; }
    public string TokenId { get; set; }
    public double Valor { get; set; }

}