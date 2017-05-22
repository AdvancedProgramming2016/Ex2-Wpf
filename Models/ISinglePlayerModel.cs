using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeMenu.Model.Listeners;

namespace MazeMenu.Models
{
    public interface ISinglePlayerModel
    {
        CommunicationClient CommunicationClient { get; set; }
        string CommandPropertyChanged { get; set; }
    }
}
