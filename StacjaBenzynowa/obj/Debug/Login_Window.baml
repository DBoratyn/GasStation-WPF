   M S B A M L   `   `   `  ����J  FStacjaBenzynowa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:StacjaBenzynowaStacjaBenzynowa  5   	   "    StacjaBenzynowa.Login_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:StacjaBenzynowa     5   	     � Title$  	Logowanie��5   	   $	��150��6   $	��350��6(    � 
ResizeMode$ CanMinimize=�64   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ label16��5      $��Login:��6!   $
��Left=�62   $��25,6,0,0q�6M   $	��Top=�5      
���   �$��Right=�6;   $��Copperplate Gothic Bold)�6^   $��26��6�   $��60��6�   �� 5   
   -   5        $ label17��5      $��Hasło:��6!   $��Right=�62   $
��Left=�6U   $��	25,32,0,0q�6p   $	��Top=�5      
���   �$��Copperplate Gothic Bold)�6;   $��26��6`   $��60��6l   �� 5   
   -   5         ��Name$ L_button��5   @   4  .System.Windows.Automation.AutomationProperties   AutomationId$ 
ZalogujBtn��6   $��Zaloguj��6t   $
��Left=�6�   $��
250,85,0,0q�6�   $	��Top=�5      $��84��6)   
���   �$��Copperplate Gothic Bold)�5   $   $��16(�6I   $
��Bold"�6W   $��26��6i   ��5   4   Z� ��6J   Z� 5   i   �� 5   
   -   5         ��Name$ loginbox��5   Z   $ loginBox��6   $
��Left=�6l   $��23��6�   $��91,6,0,0q�6�    �� TextWrapping$
 Wrap=�5      $	��Top=�6&   $	��229��6>   
���   �
���   ���5      Z� 6(   �� 5   
   -   5        $ passwordbox��5   ^   $ passwordBox��6   $
��Left=�6s   $��23��6�   $��	91,35,0,0q�6�   $
 Wrap=�5      $	��Top=�6&   $	��229��6>   
���   �
���   ���5      Z� 6(   �� 5   
   -   5        $ ErrorLbl��5      $-��'Nieprawidłowe dane uwierzytelninające��6"   
���  ��$
��Left=�6c   $��12(�6~   $��	91,63,0,0q�6�   $	��Top=�6�   $y�Hidden=�6�   $	��227��6�   $��27��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   �� 5   
   -   5        $ back_button��5      $��Wróć��6&   $
��Left=�65   $��	10,85,0,0q�6P   $	��Top=�5      $��65��6%   
���   �$��Copperplate Gothic Bold)�5       $��16(�6E   $
��Bold"�6S   $��26��6e   ��5   0   Z� ��6F   Z� 5   q   5      5      