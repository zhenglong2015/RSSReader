   M S B A M L   `   `   `  ����D  @RSSReader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:RSSReader.ViewsRSSReader.Views  5      ;"clr-namespace:RSSReader.ViewModelsRSSReader.ViewModels  5   
       RSSReader.Views.ItemWin   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:RSSReader.Views     5      9
viewModels"clr-namespace:RSSReader.ViewModels     5   
     N� Title$  ItemWin��5
       � DataContext 5      �� *	ViewModel+ �� RelativeSource ��  �� Mode$
 Self=�.��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��0��6   ��6!   �� *RItem.Title+6@   �� 5   
   $��1��6   ��6!   �� *RItem.Content+6B   �� 5   
   $��2��6   ��6!   �� *RItem.Published+6D   5      5      