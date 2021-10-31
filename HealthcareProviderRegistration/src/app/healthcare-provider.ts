export class HealthcareProvider
{
  public Firstname: string;
  public Lastname: string;
  public NpiNumber: string;
  public BusinessAddress: string;
  public TelephoneNumber: string;
  public Email: string;

   constructor(
    public firstname: string,
    public lastname: string,
    public npiNumber: string,
    public businessAddress: string,
    public telephoneNumber: string,
    public email: string
   ){
       this.Firstname = firstname;
       this.Lastname = lastname;
       this.NpiNumber = npiNumber;
       this.TelephoneNumber = telephoneNumber;
       this.Email = email;
   }
}


