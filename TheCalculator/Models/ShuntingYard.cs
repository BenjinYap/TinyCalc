﻿

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace TheCalculator.Models {
	public static class ShuntingYard {

		public static void Main (string [] args) {
			//Debug.WriteLine (Shunt ("1 * 5 - 2"));
			Debug.WriteLine (Shunt ("1 + 5 - 3 * 5 / 7"));
			//Debug.WriteLine (Shunt ("1 * 5 - 2"));
			//Debug.WriteLine (Shunt ("1 * 5 - 2"));
		}

		public static string Shunt (string input) {
			input = input.Replace (" ", "").ToLower ();

			Stack <Operator> operatorStack = new Stack <Operator> ();
			string output = "";
			
			//while input has stuff
			while (input.Length > 0) {
				//get the next token and remove it from the input
				Token token = ShuntingYard.GetToken (input);

				if (token == null) {
					break;
				}

				//remove the token from the input
				input = ReplaceFirst (input, token.Value, "");

				//do things based on the token type
				switch (token.Type) {
					case TokenType.Number:
						//add to output
						output += token.Value + " ";
						break;
					case TokenType.Operator:
						Operator op = Operator.Parse (token.Value);

						//determine whether to pop stack operator into output
						if (operatorStack.Count > 0) {
							Operator topOperator = operatorStack.Peek ();
							
							if (op.Associativity == OperatorAssociativity.Left && op.Precedence <= topOperator.Precedence ||
								op.Associativity == OperatorAssociativity.Right && op.Precedence < topOperator.Precedence) {
								output += (char) operatorStack.Pop ().Type + " ";
							}
						}

						//push operator to stack
						operatorStack.Push (op);
						break;
				}
			}

			//pop all remaining operators onto stack
			while (operatorStack.Count > 0) {
				output += (char) operatorStack.Pop ().Type + " ";
			}
			
			//trim the trailing space and return output
			return output.TrimEnd (' ');
		}

		private static Token GetToken (string input) {
			//create the token type regex patterns
			Dictionary <TokenType, string> tokenPatterns = new Dictionary <TokenType, string> ();
			tokenPatterns [TokenType.Number] = @"^\d+";
			tokenPatterns [TokenType.Operator] = @"^[+\-*/]";
			
			//check input against each pattern
			foreach (KeyValuePair <TokenType, string> pair in tokenPatterns) {
				Match match = Regex.Match (input, pair.Value);
				
				//return a token if match
				if (match.Success) {
					return new Token (pair.Key, match.Value);
				}
			}

			//return NOTHING!
			return null;
		}

		private static string ReplaceFirst (string text, string search, string replace) {
			int pos = text.IndexOf (search);

			if (pos < 0) {
				return text;
			}

			return text.Substring (0, pos) + replace + text.Substring (pos + search.Length);
		}

		private class Token {
			public TokenType Type;
			public string Value;

			public Token (TokenType type, string value) {
				this.Type = type;
				this.Value = value;
			}
		}

		private enum TokenType {
			Number,
			Operator,
		}

		private class Operator {
			public OperatorType Type;
			public int Precedence;
			public OperatorAssociativity Associativity;

			public static Operator Parse (string value) {
				Operator op = new Operator ();

				//set the operator type based on the value
				op.Type = (OperatorType) Enum.ToObject (typeof (OperatorType), (int) value [0]);

				//set the operator precedence based on the value
				string [] precedences = { "+-", "*/", "^" };

				for (int i = 0; i < precedences.Length; i++) {
					if (precedences [i].Contains (value)) {
						op.Precedence = i;
						break;
					}
				}

				//set the operator associativity based on the value
				if (value == "^") {
					op.Associativity = OperatorAssociativity.Right;
				} else {
					op.Associativity = OperatorAssociativity.Left;
				}

				return op;
			}
		}

		private enum OperatorType {
			Add = '+',
			Subtract = '-',
			Multiply = '*',
			Divide = '/',
			Exponent = '^',
		}

		private enum OperatorAssociativity {
			Left,
			Right
		}
	}
}