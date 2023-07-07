using System;
using System.Threading.Tasks;
using OpenMod.Core.Commands;
using OpenMod.Unturned.Users;
using SDG.Unturned;
using Command = OpenMod.Core.Commands.Command;

namespace MarkerRange
{
    [Command("findrange")]
    [CommandAlias("fr")]
    [CommandDescription("Find the distance between you and your marker.")]
    [CommandActor(typeof(UnturnedUser))]
    public class RangeCommand : Command
    {
        public RangeCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {}

        protected override async Task OnExecuteAsync()
        {
            var me = (UnturnedUser)Context.Actor;
            var myMarker = me.Player.Player.quests.markerPosition;
            var myPosition = me.Player.Transform.Position;
            var distance = Math.Round(Math.Sqrt(Math.Pow(myMarker.x - myPosition.X, 2) + Math.Pow(myMarker.z - myPosition.Z, 2)), 3);
            var msg = "You are " + distance + "m away from your marker.";
            await Context.Actor.PrintMessageAsync(msg);
        }
    }
}