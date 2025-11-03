using System;
using System.Linq;
using System.Text;

class Program {
    static void Main() {
        Console.WriteLine("Digite a mensagem criptografada:");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input)) {
            Console.WriteLine("Entrada não aceita.");
            return;
        }

        var bytes = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        var sb = new StringBuilder();

        foreach (var b in bytes) {
            if (b.Length != 8) {
                Console.WriteLine($"o código não possui 8 bits: {b}");
                continue;
            }

          
            var prefix = b.Substring(0, 6);
            var lastTwo = b.Substring(6, 2);
            var flippedLastTwo = new string(lastTwo.Select(c => c == '0' ? '1' : '0').ToArray());
            var afterFlip = prefix + flippedLastTwo;

            
            var decryptedByteBits = afterFlip.Substring(4, 4) + afterFlip.Substring(0, 4);

            
            int value = Convert.ToInt32(decryptedByteBits, 2);
            sb.Append((char)value);
        }

        Console.WriteLine("\nTexto descriptografado:");
        Console.WriteLine(sb.ToString());
    }
}