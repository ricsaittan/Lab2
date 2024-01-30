using System.Net.Sockets;

class Employee 
{
    private string id;
    private string name;
    private string address;
    private string phone;
    private long sin;
    private string dob;
    private string dept;

    public Employee(string Id, string Name, string Address, string Phone, long SIN, string DOB, string Dept)
    {
        this.id = Id;
        this.name = Name;
        this.address = Address;
        this.phone = Phone;
        this.sin = SIN;
        this.dob = DOB;
        this.dept = Dept;
    }

    public string toName()
    {
        return name;
    }

    public string ToStringMethod()
    {
        return $"{this.id}, {this.name}, {this.address}, {this.phone}, {this.sin}, {this.dob}, {this.dept}";
    }
    
}