   M S B A M L   `   `   `  ����B  >CtrlLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CtrlLib.UserInterface.MvvmCtrlLib.UserInterface.Mvvm  5   	   8    2CtrlLib.App.Exception.CtrlUnhandledExceptionWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9mvvm(clr-namespace:CtrlLib.UserInterface.Mvvm     5   	     � Title$  Fehler��5   	   $	��400��6   $	��800��6%   .��5	      �� $
��Auto=�6   .��5
      � $��5q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��2��6!   $
��Wrap=�65   $8��2Entschulding. Das hätte nicht passieren dürfen. ��6I   $
��Bold"�6�   $��16(�6�   �� 5   
   $��1��6   $��2��6!   $
��Wrap=�65   $m��gSollte Sie der Fehler im laufenden Betrieb stören, so wenden Sie sich bitte an den Softwareentwickler.��6I   $��0 0 0 5q�6�   $��16(�6�   �� 5   
   $��2��6   $��2��6!   $
��Wrap=�65   $S��MHier sind weitere Informationen, die uns bei der Fehlersuche helfen könnten:��6I   $��14(�6�   �� 5   
   $��3��6   $��0��6   $��	Exception��6-   $��	0 10 0 10q�6A   �� 5   
   $��3��6   $��1��6    �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�6[   $��	0 10 0 10q�6~   ��6/   �� *
CtrlName+6~   �� 5!   
   $��4��6   $��0��6   $��
StackTrace��6-   $��	0 10 0 10q�6B   �� 5"   
   $��4��6   $��1��6    . $
 Auto=�6a   $��	0 10 0 10q�6�   ��6/   �� *CtrlStackTrace+6�   �� 5$   
   $��5��6   $��0��6   $��InnerException��6-   $��	0 10 0 10q�6F   �� 5%   
   -   5        $��5��5%      $��1��6    . $
 Auto=�6�   $��	0 10 0 10q�6�   ��6/   �� *CtrlInnerException+6�   �� 5'   
   $��6��6   $��0��6   $��Message��6-   $��	0 10 0 10q�6?   �� 5(   
   $��6��6   $��1��6    . $
 Auto=�6^   $��	0 10 0 10q�6�   ��6/   �� *CtrlMessage+6�   5*      5+      5,      