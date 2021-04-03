using System;
using System.Linq;

class Program
{
    /// <summary> This method returns an array with <c>n</c> values of the Fibonacci sequence.</summary>
    /// <param name="n">Length of sequence to generate.</param>
    /// <returns>Integer array of <c>n</c> Fibonacci numbers, starting from 0</returns>
    /// <example> Example:
    /// <code>
    ///     int[] fibten = Fibonacci(3);
    /// </code>
    /// results in <c>fibten</c> containing the value [0, 1, 1].
    /// </example>
    static int[] Fibonacci(int n) {
        int[] output = new int[n];
        
        for (int i = 0; i < n; ++i) {
            if (i < 2) {
                // Initial values F_0 = 0, F_1 = 1
                output[i] = i;
            } else {
                // Subsequent values F_n = F_{n-1} + F_{n-2}
                output[i] = output[i - 1] + output[i - 2];
            }
        }
        
        return output;
    }
    
    /// <summary> Writes a sequence of integers to the standard output. </summary>
    /// <param name="s">Sequence to output.</param>
    /// <returns>Integer array of <c>n</c> Fibonacci numbers, starting from 0</returns>
    /// <example> Example:
    /// <code>
    ///     WriteSequence([1, 2, 3])
    /// </code>
    /// results in <c>1 2 3\n</c> being written to standard output.
    /// </example>
    static void WriteSequence(int[] s) {
        Console.WriteLine(string.Join(" ", s));
    }
    
    /// <summary> Runs tests for the Fibonacci() method and prints a summary to stdout. </summary>
    static void RunFibonacciTests() {
        int num_failed = 0;
        int num_passed = 0;

        // 1. Fibonacci(0) should be []
        
        Console.Write("Test Fibonacci(0): ");
        if (Enumerable.SequenceEqual(Fibonacci(0), new int[0])) {
            ++num_passed;
            Console.Write("passed\n");
        } else {
            ++num_failed;
            Console.Write("failed\n");
        }
        
        // 2. Fibonacci(1) should be [0]
        
        Console.Write("Test Fibonacci(1): ");
        if (Enumerable.SequenceEqual(Fibonacci(1), new int[] {0})) {
            ++num_passed;
            Console.Write("passed\n");
        } else {
            ++num_failed;
            Console.Write("failed\n");
        }
        
        // 3. Fibonacci(2) should be [0, 1]
        
        Console.Write("Test Fibonacci(2): ");
        if (Enumerable.SequenceEqual(Fibonacci(2), new int[] {0, 1})) {
            ++num_passed;
            Console.Write("passed\n");
        } else {
            ++num_failed;
            Console.Write("failed\n");
        }
        
        // 4. For values up to some large n, the Fibonacci property should apply
        // for the last 3 values in the sequence.
        
        Console.Write("Test Fibonacci(3 <= n <= 1024): ");
        
        bool t4_passed = true;
        for (int n = 3; n < 1024; ++n) {
            int[] seq = Fibonacci(n);
            
            if (seq[n - 1] != seq[n - 2] + seq[n - 3]) {
                t4_passed = false;
                break;
            }
        }

        if (t4_passed) {
            ++num_passed;
            Console.Write("passed\n");
        } else {
            ++num_failed;
            Console.Write("failed\n");
        }
        
        // Write summary of test cases
        Console.WriteLine(num_passed + " of " + (num_failed + num_passed) + " tests passed");
        
        if (num_failed > 0) {
            Console.WriteLine(num_failed + " failures: test suite failed");
        }
    }
    
    static void Main() {
        WriteSequence(Fibonacci(10));
        RunFibonacciTests();
    }
}
