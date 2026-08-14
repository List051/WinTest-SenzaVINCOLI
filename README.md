
## **Documentazione progetto WinTest – Libreria WinItalPascal.dll**

Il progetto **WinTest** dimostra il comportamento corretto di una libreria ben progettata come **WinItalPascal.dll**.

Quello che ho verificato è questo:

---

# ⭐ **Il progetto funziona anche cambiando DataSet, DataSource e TableAdapter**  
…perché **la libreria NON dipende dai nomi generati dal Designer**.

Questo è il punto fondamentale.

---

# **Il problema classico dei progetti WinForms**

Quando si usa il Designer di Visual Studio:

- Se hai un DataSet chiamato `ClientiDataSet`
- E poi lo ricrei o lo modifichi
- Visual Studio genera automaticamente:

```
ClientiDataSet1
ClientiDataSet2
ClientiDataSource1
ClientiDataSource2
```

Il codice scritto *dentro il form* spesso si rompe, perché dipende dai nomi generati automaticamente.

Esempio del problema classico:

```vb
Me.ClientiDataSource.DataSource = Me.ClientiDataSet
```

Se il Designer cambia i nomi → **errore**.

---

# ⭐ **Perché la libreria WinItalPascal NON si rompe?**

Perché:

### ✔️ **NON usa mai nomi generati dal Designer**  
La libreria lavora solo con oggetti generici:

- `DataGridView`
- `TextBox`
- `Form`
- `Tag`
- `Columns`
- `Rows`
- `DataTable` (se lo passi tu)
- `BindingSource` (se lo passi tu)

### ✔️ **NON fa riferimento a ClientiDataSet, ClientiDataSource, ecc.**  
Quindi non importa se il Designer crea:

- `ClientiDataSet1`
- `ClientiDataSet2`
- `ClientiDataSource1`
- `ClientiDataSource2`

La libreria **non li vede**, non li usa, non li tocca.

### ✔️ **Lavora solo con oggetti già pronti nel Form**

Esempio reale:

```vb
' DATI
dtFatture = DB.FillDataTable("SELECT * FROM Fattura")

GridUtility.FiltraTutti(FatturaDataGrid, dtOriginal, TxtTutti.Text)

CaricaDGV(ClientiDataGrid, "Select * from clienti")

GridUtility.AutoFormatForm(Me)

LogLeggiScrivi.ScriviLog("File Log", ex)   ' con nuovo file di Log
Dim leggiLog = RJMessageBox.Show(LogReader.ReadLog(), "Apro il file di log")
```

La libreria riceve:

- il Form
- i controlli dentro il Form

E formatta tutto **senza sapere da dove arrivano i dati**.

---

# **Funzione universale per salvare modifiche**

Questa funzione salva le modifiche **per qualsiasi tabella**, perché legge il nome dal `Tag`.

È inclusa nel form **FrmAprire** presente nel progetto:

```vb
Public Sub SalvaModifiche(dgv As DataGridView)
    ...
End Sub
```

---

# **Risultato: la libreria è completamente indipendente dal DataSet**

Questo significa che puoi:

### ✔️ cambiare DataSet  
### ✔️ cambiare TableAdapter  
### ✔️ cambiare DataSource  
### ✔️ cambiare nomi delle tabelle  
### ✔️ aggiungere nuove tabelle  
### ✔️ ricreare il DataSet da zero  

 **E WinItalPascal continua a funzionare al 100%**,  
perché non dipende da nulla di tutto questo.

---

#  **Ho creato una libreria robusta e professionale**

La libreria WinItalPascal segue gli stessi principi delle librerie commerciali:

- **non dipende dal Designer**
- **non dipende dai nomi dei DataSet**
- **non dipende dai TableAdapter**
- **non dipende dai BindingSource generati automaticamente**

Lavora **solo con oggetti generici**, quindi è:

- riutilizzabile  
- indipendente  
- stabile  
- sicura  
- compatibile con qualsiasi progetto  

---

#  **Nel progetto trovi in `\bin\WinItalPascal.dll` (versione aggiornata)**

Modifiche incluse:

- ✔️ Eliminato il bug per spostare la finestra  
- ✔️ Aggiunta funzione per formattare correttamente i valori numerici  

---

# **YouTube – Playlist dedicata**

Canale:  
[https://www.youtube.com/@iaoraGo](https://www.youtube.com/@iaoraGo)

Playlist:  
[https://www.youtube.com/watch?v=3FkO8yAd0Mg&list=PLqYE2xAtyfEAiNY4qC2LeJJuCJPyUScXL](https://www.youtube.com/watch?v=3FkO8yAd0Mg&list=PLqYE2xAtyfEAiNY4qC2LeJJuCJPyUScXL)

---

Troverai anche un video dimostrativo nella mia PlayList
https://youtu.be/tn6D89N6eV4
