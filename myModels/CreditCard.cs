namespace myModels
{
    public class CreditCard
    {
        public long creditNum { get; set; }
        public string validity { get; set; }
        public int threeDigit { get; set; }
    public CreditCard(long creditNum ,string validity,int threeDigit){
        this.creditNum = creditNum;
        this.validity = validity;
        this.threeDigit = threeDigit;
    }
    

    }
}