   M S B A M L   `   `   `  ����K  GReportServiceWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Page_Navigation_App.ViewModelPage_Navigation_App.ViewModel  5   	   2    ,ReportServiceProjectWPF.MVVM.Views.UsersView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   :vm+clr-namespace:Page_Navigation_App.ViewModel     5   	   $	��500��5   	   $	��650��6     � DataContext  5      2   ,Page_Navigation_App.ViewModel.UsersViewModel  5   
   .��5	      � ���#212529 � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��50��6X   $	��Top=�6d   .+�5      �� -   5         ��Name$ searchTextBox��5      $	��285��6U   $��30��6a   $��Center=�6m   $��0 0 50 0q�6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ userGrid��5       $��1��6      AutoGenerateColumns$ False��62   $��10,21,34,84q�6N      
IsReadOnly$
 True��6c   $
{�True��6u    � 	Resources 5      )  #System.Windows.Controls.DataGridRow �� 
TargetType	 �� Property
 �� Value��%X   '        �� 5      "  6   .�5      �� 	 � ��
 �#1976D263   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID+  5      $ Username��6%    67   �� *
Username+  5      $
 Name��6%    63   �� *Name+  5      $ Password��6%    67   �� *
Password+  5      $ 	Birthdate��6%    68   �� *	Birthdate+  5      $	 Age��6%    62   �� *Age+  5       $ Email��6%    64   �� *Email+5"      �� 5$   
   -   5        $��Додати��5$      $
��Left=�6>   $��Bottom=�6Y   $��1��6t   $��
123,0,0,27q�6�   $��90��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��31��6�   z�5%      V� 5&      .~�5'      �� �� 5(      �� 5)       �� Angle$ 0Q�6&   T� 5*      5+      5-      �� 5.   
   -   5        $��Видалити��5.      $
��Left=�6D   $��Bottom=�6_   $��1��6z   $��
346,0,0,27q�6�   $��31��6�   $��83��6�   �� 5/   
   -   5        $��Редагувати��5/      $
��Left=�6D   $��Bottom=�6_   $��1��6z   $��
236,0,0,27q�6�   $ 0.5,0.5&�6�   $��31��6�   $��89��6�   z�50      V� 51      .~�52      �� �� 53      �� 54      $ 0Q�6&   T� 55      56      58      59      5:      