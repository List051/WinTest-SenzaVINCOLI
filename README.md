<p align="center">
  <img src="logo.png" alt="Ital Pascal Logo" width="220">
</p>

<h1 align="center">WinItalPascal</h1>
<p align="center">
  Libreria di utilità per applicazioni VB.NET WinForms
</p>

<p align="center">

  <!-- NuGet -->
  <a href="https://www.nuget.org/packages/WinItalPascal">
    <img src="https://img.shields.io/nuget/v/WinItalPascal?style=for-the-badge" alt="NuGet Version">
  </a>
  <a href="https://www.nuget.org/packages/WinItalPascal">
    <img src="https://img.shields.io/nuget/dt/WinItalPascal?style=for-the-badge" alt="NuGet Downloads">
  </a>

  <!-- GitHub -->
  <img src="https://img.shields.io/github/stars/List051?style=for-the-badge" alt="Stars">
  <img src="https://img.shields.io/github/forks/List051/WinItalPascal_Lib?style=for-the-badge" alt="Forks">
  <img src="https://img.shields.io/github/issues/List051/WinItalPascal_Lib?style=for-the-badge" alt="Issues">
  <img src="https://img.shields.io/github/last-commit/List051/WinItalPascal_Lib?style=for-the-badge" alt="Last Commit">

  <!-- License -->
  <a href="https://github.com/List051/WinItalPascal_Lib/blob/main/License.txt">
    <img src="https://img.shields.io/github/license/List051/WinItalPascal_Lib?style=for-the-badge" alt="License">
  </a>

</p>

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

---

# 🔗 Link utili

## 📚 Documentazione della libreria WinItalPascal

- [📘 Documentazione Tecnica (*.md)](https://github.com/List051/WinItalPascal_Lib/tree/main/Documentation)
- [📄 Manuali PDF della libreria](https://github.com/List051/WinItalPascal_Lib/tree/main/Help/pdf)

---

## 🎬 Video dimostrativi

- [🎥 Video Esempi – WinVideoShowcase](https://list051.github.io/WinVideoShowcase/)
- [📺 Canale YouTube](https://www.youtube.com/@iaoraGo)
- [🎞️ Playlist completa WinItalPascal](https://www.youtube.com/watch?v=UboNebA_Irs&list=PLqYE2xAtyfEAiNY4qC2LeJJuCJPyUScXL)

---


<div align="center">
  <h2>⭐ Come supportare il progetto</h2>
  <p>Se questo progetto ti è utile, puoi supportarlo con un semplice gesto:</p>

  <!-- Pulsante Star -->
  <a href="https://github.com/List051/WinTest-SenzaVINCOLI">
    <img src="https://img.shields.io/github/stars/List051/WinTest-SenzaVINCOLI?style=social" alt="Star this repo">
  </a>

  <!-- Pulsante Fork -->
  <a href="https://github.com/List051/WinTest-SenzaVINCOLI/fork">
    <img src="https://img.shields.io/github/forks/List051/WinTest-SenzaVINCOLI?label=fork&style=social" alt="Fork this repo">
  </a>

  <p>Mettere una ⭐ o fare un Fork aiuta il progetto a crescere e permette ad altri sviluppatori di scoprirlo.</p>

  <br>

  <!-- Pulsante Follow autore -->
  <p>Vuoi restare aggiornato sui nuovi progetti?</p>

  <a href="https://github.com/List051">
    <img src="https://img.shields.io/github/followers/List051?label=Follow%20%40List051&style=social" alt="Follow @List051">
  </a>

  <p>Grazie per il tuo supporto!</p>
</div>

---

