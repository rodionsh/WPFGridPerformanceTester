   M S B A M L   `   `   `  ���� K  GWPFExampleTester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WPFExampleTester.ViewModelsWPFExampleTester.ViewModels  &     WPFExampleTester.Views.BasicView   a ]DevExpress.Xpf.Core.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ] YDevExpress.Mvvm.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  j fDevExpress.Xpf.LayoutControl.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  :
ViewModels)clr-namespace:WPFExampleTester.ViewModels  a ]DevExpress.Xpf.Grid.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v16.2.Core, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	   � DataContext  0   *WPFExampleTester.ViewModels.BasicViewModel  .��� .+�0  *DevExpress.Xpf.LayoutControl.LayoutControl  .  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�.+�  .+�  -     Name$ layoutGroup��$ Vertical=�$	��Top=�.+�-  'DevExpress.Xpf.LayoutControl.LayoutItem     Content. %  DevExpress.Xpf.Grid.GridControl  -     Name$ BookControl��$	��500��$��11(�|�.  $
��Left=�$	��Top=�$��Disabled=�$��Disabled=�) 	 #DevExpress.Xpf.Grid.DataControlBase   ItemsSource �� *SortedBookView+   Columns $  DevExpress.Xpf.Grid.GridColumn  $ 	 DevExpress.Xpf.Grid.ColumnBase   	FieldName$ BWork��
   Tag$ BCLEAR��$	 	 DevExpress.Xpf.Grid.BaseColumn	 	  Header)
  #DevExpress.Xpf.Core.ObjectConverter$
	 Work
 
 	  Width2 	 ,DevExpress.Xpf.Grid.GridColumnWidthConverter$
 35    AllowSorting]
 YDevExpress.Data.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 
 /DevExpress.Utils.Design.DefaultBooleanConverter$ False    AllowColumnFiltering$ False ' 	   HorizontalHeaderContentAlignment$
 Left=�   
AllowFocus .     ReadOnly .    EditSettings 6  0DevExpress.Xpf.Editors.Settings.TextEditSettings  6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings!   HorizontalContentAlignment$
 Left=�  $
 Bids��$	 BUY��$
	 Bids
 $
 40 $ False $ False $ Right=� .   .    $ Right=�  $ Price��$ PRICE��$	  
 $
 50 $ False $ False $ Center=� .   .    $ Center=�  $
 Asks��$
 SELL��$
	 Asks
 $
 40 $ False $ False $
 Left=� .   .    $
 Left=�  $ AWork��$ SCLEAR��$
	 Work
 $
 35 $ False $ False $ Right=� .   .    $ Right=�   View #  DevExpress.Xpf.Grid.TableView     AllowPerPixelScrolling .  & 	  DevExpress.Xpf.Grid.DataViewBase   AllowEditing .  &   DevExpress.Xpf.Grid.GridViewBase   AllowGrouping .     AllowColumnMoving .     AllowResizing .     AllowSorting .     NavigationStyle$	 Row=�   	AutoWidth .     AllowFixedGroups$ False    ShowGroupPanel .    . &   DevExpress.Xpf.Core.SimpleButton  $��	Randomize������ *	Randomize+