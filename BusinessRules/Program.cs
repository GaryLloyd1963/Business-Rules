using System;
using System.Collections.Generic;
using BusinessRules.ActionsSource;
using BusinessRules.ActionsSourceProcessor;
using BusinessRules.Core;
using BusinessRules.Domain;
using StructureMap;

namespace BusinessRules
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerManager.InitialiseContainer();

            var actionSourceProcessor = container.GetInstance<IActionsSourceProcessor>();

            var paymentReceivedA = ProcessHelper.CreatePaymentReceivedForAnItem(ProductConstants.MainProductType.Physical, ProductConstants.SubProductType.Book, "Jabberwocky");
            var paymentReceivedB = ProcessHelper.CreatePaymentReceivedForAnItem(ProductConstants.MainProductType.NonPhysical, ProductConstants.SubProductType.Membership, "Central Gym");
            var paymentReceivedC = ProcessHelper.CreatePaymentReceivedForAnItem(ProductConstants.MainProductType.NonPhysical, ProductConstants.SubProductType.MembershipUpgrade, "City Gym");

            var actionsSourceFactory = container.GetInstance<IActionsSourceFactory>();

            var actionsSources = new List<IActionsSource>
            {
                actionsSourceFactory.ActionSource(paymentReceivedA),
                actionsSourceFactory.ActionSource(paymentReceivedB),
                actionsSourceFactory.ActionSource(paymentReceivedC)
            };

            foreach (var actionsSource in actionsSources)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine($"Processing {actionsSource.GetDescription()}");
                Console.WriteLine("------------------------------------------------------");
                actionSourceProcessor.CreateAndPerformActions(actionsSource);
                Console.WriteLine("------------------------------------------------------");
            }

            Console.ReadKey();
        }
    }
}
