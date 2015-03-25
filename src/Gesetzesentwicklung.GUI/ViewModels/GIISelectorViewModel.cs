﻿using Caliburn.Micro;
using Gesetzesentwicklung.GII;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesetzesentwicklung.GUI.ViewModels
{
    public class GIISelectorViewModel : PropertyChangedBase
    {
        private string _gesetzesFilter;

        private ObservableCollection<string> _gesetzeImInternet;

        public string GesetzesFilter
        {
            get { return _gesetzesFilter; }
            set
            {
                _gesetzesFilter = value;
                NotifyOfPropertyChange(() => GesetzesFilter);
            }
        }

        public ObservableCollection<string> GesetzeImInternet
        {
            get { return _gesetzeImInternet; }
            set
            {
                _gesetzeImInternet = value;
                NotifyOfPropertyChange(() => GesetzeImInternet);
            }
        }

        public GIISelectorViewModel()
        {
            _gesetzesFilter = "Bla blub";
            _gesetzeImInternet = new ObservableCollection<string>();
 
            Task.Run(() =>
            {
                var verzeichnisLader = new VerzeichnisLader();
                var xmlVerzeichnis = verzeichnisLader.LadeVerzeichnis().Result;
                foreach (var norm in xmlVerzeichnis.Normen)
                {
                    Execute.OnUIThread(() => GesetzeImInternet.Add(norm.Titel));
                }
            });
        }
    }
}
