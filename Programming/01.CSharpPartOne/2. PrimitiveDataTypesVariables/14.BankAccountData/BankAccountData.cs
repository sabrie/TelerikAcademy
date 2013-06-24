/* A bank account has a holder name (first name, middle name and last name), 
 * available amount of money (balance), bank name, IBAN, BIC code and 3 credit 
 * card numbers associated with the account. Declare the variables needed to 
 * keep the information for a single bank account using the appropriate data 
 * types and descriptive names.
 */
using System;

class BankAccountData
{
    static void Main()
    {
        string holderFirstName = "Sabrie";
        string holderMiddleName = "Tugay";
        string holderFamilyName = "Nedzhip";
        decimal balance = 1234567.89M;
        string bankName = "UniCreditBulbank";
        string iBAN = "BG41UNCR12345678912345";
        string bIC = "UNCRBGSF";
        ulong creditCardNumber1 = 12345678912345678L;
        ulong creditCardNumber2 = 11223344556677889L;
        ulong creditCardNumber3 = 11122233344455566L;

        Console.WriteLine("First Name: " + holderFirstName);
        Console.WriteLine("Middle Name: " + holderMiddleName);
        Console.WriteLine("Family Name: " + holderFamilyName);
        Console.WriteLine("Balance: " + balance);
        Console.WriteLine("Bank Name: " + bankName);
        Console.WriteLine("IBAN: " + iBAN);
        Console.WriteLine("BIC: " + bIC);
        Console.WriteLine("Credit Card 1: " + creditCardNumber1);
        Console.WriteLine("Credit Card 2: " + creditCardNumber2);
        Console.WriteLine("Credit Card 3: " + creditCardNumber3);
    }
}

