   M S B A M L   `   `   `  ����J  FStacjaBenzynowa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:StacjaBenzynowaStacjaBenzynowa  5   	   $    StacjaBenzynowa.Booking_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:StacjaBenzynowa     5   	     � Title$  
Rezerwacja��5   	   $	��306��6   $	��800��6)    � 
ResizeMode$ CanMinimize=�65   .��5	      � 
�������$	��278��6   $	��Top=�6+   .+�5
   
   �� -   5         ��Name$ back_button��5
      $��Wróć��6'   $
��Left=�66   $��
53,216,0,0q�5      $	��Top=�6!   $��60��69   
���   �$��Copperplate Gothic Bold)�5       $��16(�6E   $
��Bold"�6S   ��5   D   Z� ��6Z   Z� 5   e   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DateReservation��5      $
��Left=�6.   $��
136,87,0,0q�6I   $	��Top=�6]    J� RenderTransformOrigin$ 0.167,0.479&�6u   $	��184��6�   �� 5   
   -   5         ��Name$ Adres_firmy��5      $��Date:��6%   $��Center=�65   $
��Left=�6Y   $��	13,87,0,0q�5      $	��Top=�6    $	��123��68   ���	#FFFFFDFD$��Copperplate Gothic Bold)�6[   $��16(�5      $
��Bold"�6   $��Italic$�6C   ��6-   Z� 6C   �� 5   
   -   5        $
 Time��5      $��Godzina:��6   $��Center=�61   $
��Left=�6U   $��-101,121,0,0q�5      $	��Top=�6#   $	��357��6;   
���   �$��Copperplate Gothic Bold)�6Z   $��16(�5      $
��Bold"�6   $��Italic$�6C   ��6-   Z� 6C   �� 5   
   -   5         ��Name$
 Hour��5      $
��Left=�6?   $��136,127,0,0q�6Z   $	��Top=�6o   $��72��6�   ���	#FFFFFDFD��6!   �� *hours+��5      �� 5       �� EndPoint$	 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��5      � 	 � Color$	 	#FFF0F0F0��6#   
 � Offset$
 0Q�65   � 5      $	 	#FFFFFDFD��6#   $
 1Q�65   5      5      �� 5   
   -   5        $ Minute��5      $��Visible=�6#   $
��Left=�6V   $��232,127,0,0q�6q   $	��Top=�6�   $��88��6�   �� 5   
   $��:��6   $��Center=�6   $
��Left=�6@   $��213,127,0,0q�5      $	��Top=�6"   $��15��6:   
���   �$��Copperplate Gothic Bold)�6X   $��16(�5      $
��Bold"�6   $��Italic$�6C   $ 0.711,-0.557&�6V   ��6-   Z� 6V   �� 5    
   -   5        $ Reserve��5       $��Rezerwuj��6"   $
��Left=�65   $��232,216,0,0q�6P   $	��Top=�6e   $	��117��6}   $��Copperplate Gothic Bold)�6�   $��16(�6�   ��6�   Z� ��6�   Z� 6�   �� 5!   
   -   5         ��Name$ BookingListView��5!   (   $y�Visible=�6   $��371,49,10,22q�5"      $��Disabled=�5#      $��1��6I   ���	#FF020202
���   ���5"   *   Z� ��5$      �� 5%      .R�5&      ��  �� Orientation$ Vertical=�6!   $��Disabled=�68   .+�5'      �� $��15(�6Y   $��Italic$�6g   $
��Wrap=�6z   $��Copperplate Gothic Bold)�6�   ��6$   ��  �� Path$
 Date� �� StringFormat$ 	Data: {0}��6�   �� 5(      $��15(�6\   $��Italic$�6j   $
��Wrap=�6}   $��Copperplate Gothic Bold)�6�   ��6$   �� $
 Hour�$ Godzina: {0}��6�   �� 5)      $��15(�6]   $��Italic$�6k   $
��Wrap=�6~   $��Copperplate Gothic Bold)�6�   ��6$   �� $ Minute�$ Minuta: {0}��6�   5*      5+      5-      �� 5.   
   -	   5        $ Adres_firmy_Copy��5.      $��Data:��6*   $��Center=�6:   $
��Left=�6^   $��	13,87,0,0q�5/      $	��Top=�6    $	��123��68   
���   �$��Copperplate Gothic Bold)�6W   $��16(�50      $
��Bold"�6   $��Italic$�6C   $ 2.163,-0.964&�6V   ��6-   Z� 6V   �� 51   
   -
   5        $ Adres_firmy_Copy1��51      $��
REZERWACJE��6+   $��Center=�6@   $
��Left=�6d   $��
491,21,0,0q�52      $	��Top=�6!   $	��192��69   
���   �$��Copperplate Gothic Bold)�6X   $��16(�53      $
��Bold"�6   $��Italic$�6C   $ 2.163,-0.964&�6V   ��6-   Z� 6V   54      55      