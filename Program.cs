
using System.Text;

ulong firstNumber = 2345678901;
ulong secondNumber = 8956324567;

byte[] firstNumberBytes = Encoding.ASCII.GetBytes(firstNumber.ToString());
byte[] secondNumberString = Encoding.ASCII.GetBytes(secondNumber.ToString());

byte maxLenght = GetMaxLenghtInBytes(firstNumberBytes, secondNumberString);

int countDozens = 0;

BaseLogic(maxLenght, firstNumberBytes, secondNumberString, ref countDozens);

byte[] newResult = null!;
AddHighBiteNumber(countDozens, firstNumberBytes, ref newResult);


PrintResult(newResult, firstNumber, secondNumber);



//metods

static int GetMaxLenght(string first, string second)
{
    if (first.ToString().Length > second.ToString().Length) return first.ToString().Length;
    else return second.ToString().Length;
}

static byte GetMaxLenghtInBytes(byte[] first, byte[] second)
{
    if (first.Length > second.Length) return (byte)first.Length;
    else return (byte)second.Length;
}

static void PrintResult(byte[] newResult, ulong firstNumber, ulong secondNumber)
{
    foreach (var item in newResult)
    {
        Console.Write(item);
    }
    Console.Write(" == " + (firstNumber + secondNumber));
}

static void AddHighBiteNumber(int countDozens, byte[] firstNumberBytes, ref byte[] newResult)
{
    int newLenght = firstNumberBytes.Length + 1;
    newResult = new byte[newLenght];
    if (countDozens > 0)
    {
        firstNumberBytes.CopyTo(newResult, 1);
        newResult[0] = (byte)countDozens;
    }
}


static void BaseLogic(byte maxLenght, byte[] firstNumberBytes, byte[] secondNumberString,
    ref int countDozens)
{
    for (int i = maxLenght - 1; i >= 0; i--)
    {
        int first = firstNumberBytes[i] - '0';
        int second = secondNumberString[i] - '0';
        countDozens = first + second + countDozens;
        firstNumberBytes[i] = (byte)(countDozens % 10);

        countDozens = countDozens / 10;
    }
}