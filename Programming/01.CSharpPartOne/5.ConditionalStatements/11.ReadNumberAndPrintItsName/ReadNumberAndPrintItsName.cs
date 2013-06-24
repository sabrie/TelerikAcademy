/* *Write a program that converts a number in the range [0...999]
 * to a text corresponding to its English pronunciation. 
 * Examples:
	0 -> "Zero"
	273 -> "Two hundred seventy three"
	400 -> "Four hundred"
	501 -> "Five hundred and one"
	711 -> "Seven hundred and eleven"
*/
using System;

class ReadNumberAndPrintItsName
{
    static void Main()
    {
        Console.WriteLine("Enter a number to read its name: ");
        int number = int.Parse(Console.ReadLine());
        int hundreds = number / 100;
        int tens = (number - hundreds * 100) / 10;
        int ones = number % 10;

        switch (hundreds)
        {
            case 1:
                Console.Write("One hundred ");
                break;
            case 2:
                Console.Write("Two hundred ");
                break;
            case 3:
                Console.Write("Three hundred ");
                break;
            case 4:
                Console.Write("Four hundred ");
                break;
            case 5:
                Console.Write("Five hundred ");
                break;
            case 6:
                Console.Write("Six hundred ");
                break;
            case 7:
                Console.Write("Seven hundred ");
                break;
            case 8:
                Console.Write("Eight hundred ");
                break;
            case 9:
                Console.Write("Nine hundred ");
                break;
            default:
                Console.Write("");
                break;
        }

        if (tens != 1)
        {
            if (hundreds != 0)
            {
                switch (tens)
                {
                    case 2:
                        Console.Write("twenty ");
                        break;
                    case 3:
                        Console.Write("thirty ");
                        break;
                    case 4:
                        Console.Write("fourty ");
                        break;
                    case 5:
                        Console.Write("fifty ");
                        break;
                    case 6:
                        Console.Write("sixty ");
                        break;
                    case 7:
                        Console.Write("seventy ");
                        break;
                    case 8:
                        Console.Write("eighty ");
                        break;
                    case 9:
                        Console.Write("ninety ");
                        break;
                    default:
                        Console.Write("");
                        break;
                }
            }
            else
            {
                switch (tens)
                {
                    case 2:
                        Console.Write("Twenty ");
                        break;
                    case 3:
                        Console.Write("Thirty ");
                        break;
                    case 4:
                        Console.Write("Fourty ");
                        break;
                    case 5:
                        Console.Write("Fifty ");
                        break;
                    case 6:
                        Console.Write("Sixty ");
                        break;
                    case 7:
                        Console.Write("Seventy ");
                        break;
                    case 8:
                        Console.Write("Eighty ");
                        break;
                    case 9:
                        Console.Write("Ninety ");
                        break;
                    default:
                        Console.Write("");
                        break;
                }
            }
            if (hundreds != 0)
            {
                if (tens == 0)
                {
                    switch (ones)
                    {
                        case 1:
                            Console.Write("and one");
                            break;
                        case 2:
                            Console.Write("and two");
                            break;
                        case 3:
                            Console.Write("and three");
                            break;
                        case 4:
                            Console.Write("and four");
                            break;
                        case 5:
                            Console.Write("and five");
                            break;
                        case 6:
                            Console.Write("and six");
                            break;
                        case 7:
                            Console.Write("and seven");
                            break;
                        case 8:
                            Console.Write("and eight");
                            break;
                        case 9:
                            Console.Write("and nine");
                            break;
                        default:
                            Console.Write("");
                            break;
                    }
                }
                else
                {
                    switch (ones)
                    {
                        case 1:
                            Console.Write("one");
                            break;
                        case 2:
                            Console.Write("two");
                            break;
                        case 3:
                            Console.Write("three");
                            break;
                        case 4:
                            Console.Write("four");
                            break;
                        case 5:
                            Console.Write("five");
                            break;
                        case 6:
                            Console.Write("six");
                            break;
                        case 7:
                            Console.Write("seven");
                            break;
                        case 8:
                            Console.Write("eight");
                            break;
                        case 9:
                            Console.Write("nine");
                            break;
                        default:
                            Console.Write("");
                            break;
                    }
                }
            }
            else
            {
                if (hundreds == 0 && tens == 0)
                {
                    switch (ones)
                    {
                        case 1:
                            Console.Write("One");
                            break;
                        case 2:
                            Console.Write("Two");
                            break;
                        case 3:
                            Console.Write("Three");
                            break;
                        case 4:
                            Console.Write("Four");
                            break;
                        case 5:
                            Console.Write("Five");
                            break;
                        case 6:
                            Console.Write("Six");
                            break;
                        case 7:
                            Console.Write("Seven");
                            break;
                        case 8:
                            Console.Write("Eight");
                            break;
                        case 9:
                            Console.Write("Nine");
                            break;
                        default:
                            Console.Write("");
                            break;
                    }
                }
                else
                {
                    switch (ones)
                    {
                        case 1:
                            Console.Write("one");
                            break;
                        case 2:
                            Console.Write("two");
                            break;
                        case 3:
                            Console.Write("three");
                            break;
                        case 4:
                            Console.Write("four");
                            break;
                        case 5:
                            Console.Write("five");
                            break;
                        case 6:
                            Console.Write("six");
                            break;
                        case 7:
                            Console.Write("seven");
                            break;
                        case 8:
                            Console.Write("eight");
                            break;
                        case 9:
                            Console.Write("nine");
                            break;
                        default:
                            Console.Write("");
                            break;
                    }

                }
            }
        }
        else
        {
            if (hundreds != 0)
            {
                switch (ones)
                {
                    case 1:
                        Console.Write("and eleven");
                        break;
                    case 2:
                        Console.Write("and twelve");
                        break;
                    case 3:
                        Console.Write("and thirteen");
                        break;
                    case 4:
                        Console.Write("and fourteen");
                        break;
                    case 5:
                        Console.Write("and fifteen");
                        break;
                    case 6:
                        Console.Write("and sixteen");
                        break;
                    case 7:
                        Console.Write("and seventeen");
                        break;
                    case 8:
                        Console.Write("and eighteen");
                        break;
                    case 9:
                        Console.Write("and nineteen");
                        break;
                    default:
                        Console.Write("and ten");
                        break;
                }
            }
            else
            {
                switch (ones)
                {
                    case 1:
                        Console.Write("Eleven");
                        break;
                    case 2:
                        Console.Write("Twelve");
                        break;
                    case 3:
                        Console.Write("Thirteen");
                        break;
                    case 4:
                        Console.Write("Fourteen");
                        break;
                    case 5:
                        Console.Write("Fifteen");
                        break;
                    case 6:
                        Console.Write("Sixteen");
                        break;
                    case 7:
                        Console.Write("Seventeen");
                        break;
                    case 8:
                        Console.Write("Eighteen");
                        break;
                    case 9:
                        Console.Write("Nineteen");
                        break;
                    default:
                        Console.Write("Ten");
                        break;
                }
            }
        }
        Console.WriteLine();
        Main();
    }
}

