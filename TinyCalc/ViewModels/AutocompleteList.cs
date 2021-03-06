﻿

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TinyCalc.Localization;
using TinyCalc.Models.Modules;
namespace TinyCalc.ViewModels {
	public class AutocompleteList:ObservableCollection <AutocompleteItem> {
		private int selectedIndex;
		public int SelectedIndex { 
			get { return this.selectedIndex; }
			set {
				this.selectedIndex = value;
				this.OnPropertyChanged (new PropertyChangedEventArgs ("SelectedIndex"));
			}
		}

		public string SelectedItemName {
			get { return this [this.SelectedIndex].Name; }
		}

		public bool IsPopulated { get { return this.Count > 0; } }

		private List <AutocompleteItem> allItems = new List <AutocompleteItem> ();

		private bool isSuspended = false;

		public AutocompleteList () {
			this.SelectedIndex = -1;

			//retrieve the tokens from the modules
			//add them to the master list along with the descriptions of each
			List <string> tokens = new FunctionModule ().GetTokens ();

			foreach (string token in tokens) {
				this.allItems.Add (new AutocompleteItem (AutocompleteItemType.Function, token, Autocomplete.ResourceManager.GetString (token)));
			}

			tokens = new ConstantModule ().GetTokens ();

			foreach (string token in tokens) {
				this.allItems.Add (new AutocompleteItem (AutocompleteItemType.Constant, token, Autocomplete.ResourceManager.GetString (token)));
			}

			//sort by alpha
			this.allItems.Sort (new Comparison <AutocompleteItem> ((x, y) => x.Name.CompareTo (y.Name)));
		}

		protected override void OnCollectionChanged (System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
			base.OnCollectionChanged (e);
			
			if (this.isSuspended == false) {
				//notify this property for the lovely front end
				this.OnPropertyChanged (new PropertyChangedEventArgs ("IsPopulated"));
			}
		}

		public void Reset () {
			this.Clear ();
			this.SelectedIndex = -1;
		}

		public void PopulateAll () {
			//show the master list
			this.Reset ();

			foreach (AutocompleteItem item in this.allItems) {
				this.Add (item);
			}

			this.SelectedIndex = 0;
		}

		public void Populate (string token) {
			this.isSuspended = true;

			//reset the list
			this.Reset ();

			this.isSuspended = false;

			//default selection
			this.SelectedIndex = 0;

			//if token is empty, show the master list
			if (string.IsNullOrWhiteSpace (token)) {
				return;
			}

			//populate autocomplete list with items that contain the token
			for (int i = 0; i < this.allItems.Count; i++) {
				AutocompleteItem item = this.allItems [i];

				if (item.Name.IndexOf (token) == 0) {
					this.Add (item);
				}
			}

			//set selected item to the first item that matches the token from the start of the string
			for (int i = 0; i < this.Count; i++) {
				if (this [i].Name.IndexOf (token) == 0 && this.SelectedIndex == -1) {
					this.SelectedIndex = i;
				}
			}
		}
	}
}
