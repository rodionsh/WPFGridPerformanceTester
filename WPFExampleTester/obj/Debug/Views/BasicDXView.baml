   M S B A M L   `   `   `  ����S  OWPFGridPerformanceTester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WPFExampleTester.ViewModelsWPFExampleTester.ViewModels  5
   	   ?$clr-namespace:WPFExampleTester.ViewsWPFExampleTester.Views  5   	   (    "WPFExampleTester.Views.BasicDXView   5   	   a ]DevExpress.Xpf.Core.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   ] YDevExpress.Mvvm.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   j fDevExpress.Xpf.LayoutControl.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5	   	   :
ViewModels)clr-namespace:WPFExampleTester.ViewModels  5
   	   a ]DevExpress.Xpf.Grid.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v16.2.Core, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5   	   2local$clr-namespace:WPFExampleTester.Views  	 5   	     � DataContext  5      2   ,WPFExampleTester.ViewModels.BasicDXViewModel  5   
   .��5      � .+�5   
   0  *DevExpress.Xpf.LayoutControl.LayoutControl  .  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�6   .+�5        .+�5        -   5          Name$ layoutGroup��5   #   $ Vertical=�68   $	��Top=�6O   .+�5      -  'DevExpress.Xpf.LayoutControl.LayoutItem     Content. 5      %  DevExpress.Xpf.Grid.GridControl  -   5          Name$ BookControl��5   *   $	��500��6?   $��11(�6L   |�.  $
��Left=�5   !   $	��Top=�5   !   $��Disabled=�5   !   $��Disabled=�5   !   ) 	 #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 5   !   �� *SortedBookView+.   (WPFExampleTester.Views.UpdatesLockHelper   IsUpdatesDXLocked 5   !   �� *IsUpdatesDXLocked+   Columns 5       $  DevExpress.Xpf.Grid.GridColumn  5!   "   $	 	 DevExpress.Xpf.Grid.ColumnBase 	  	FieldName$ BWork��61   
	 	  Tag$	 BCLEAR��6C   $
 	 DevExpress.Xpf.Grid.BaseColumn
 
  Header)  #DevExpress.Xpf.Core.ObjectConverter$

 Work 6P    
  Width2 	 ,DevExpress.Xpf.Grid.GridColumnWidthConverter$ 35 6^    	  AllowSorting]
 YDevExpress.Data.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 
 /DevExpress.Utils.Design.DefaultBooleanConverter$ False 6i    	  AllowColumnFiltering$ False 6~   ' 
   HorizontalHeaderContentAlignment$
 Left=�6�    	  
AllowFocus .   	  ReadOnly .  	  EditSettings 5"   &   6  0DevExpress.Xpf.Editors.Settings.TextEditSettings  5#   *   6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings!   HorizontalContentAlignment$
 Left=�6?   5%   #     5&   "   $
 Bids��61   $		 BUY��6B   $

 Bids 6L   $ 40 6Z   $ False 6e   $ False 6z   $ Right=�6�    .   .  5'   &     5(   *   $ Right=�6?   5*   #     5+   "   $ Price��61   $	 PRICE��6C   $
   6O   $ 50 6Z   $ False 6e   $ False 6z   $ Center=�6�    .   .  5,   &     5-   *   $ Center=�6?   5/   #     50   "   $
 Asks��61   $
	 SELL��6B   $

 Asks 6M   $ 40 6[   $ False 6f   $ False 6{   $
 Left=�6�    .   .  51   &     52   *   $
 Left=�6?   54   #     55   "   $ AWork��61   $	 SCLEAR��6C   $

 Work 6P   $ 35 6^   $ False 6i   $ False 6~   $ Right=�6�    .   .  56   &     57   *   $ Right=�6?   59   #      View 5;      #  DevExpress.Xpf.Grid.TableView  5<   "   -   5          Name$ BookTableView��5<   0      AllowPerPixelScrolling .  & 	  DevExpress.Xpf.Grid.DataViewBase   AllowEditing .  &   DevExpress.Xpf.Grid.GridViewBase   AllowGrouping .     AllowColumnMoving .     AllowResizing .     AllowSorting .     NavigationStyle$	 Row=�6�      	AutoWidth .     AllowFixedGroups$ False 6�      ShowGroupPanel .  6  5>      5?        5@      . 5A      &   DevExpress.Xpf.Core.SimpleButton  $��	Randomize��6*   ��6>   �� *	Randomize+5B      5C      5D      5E      5F      5G      