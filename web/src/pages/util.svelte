<script lang="ts" context="module">
  import type {Wilayah} from './model.svelte';
  const wilayahs: Array<Wilayah> = [];

  export const getData = async () => {

    // const url = 'http://localhost:8028/kodepos/kodepos.extended.json';
    const url = 'https://raw.githubusercontent.com/erlange/Kodepos-Wilayah-Indonesia/master/json/kodepos.extended.json';

    let data = [];

    await fetch(url)
      .then(d => d.json())
      .then(dt => {
        data = dt;
    });
    
    Object.entries(data).map(([k1,v1]) => {
      return {'id': v1['ID'], 'propName': k1, 'kabu': 
            Object.entries(v1['Kabupaten/Kota']).map(([k2,v2]) => {
              return {'id': v2['ID'], 'kabuName': k2, 'keca': 
              Object.entries(v2['Kecamatan']).map(([k3,v3]) => {
                return {'id': v3['ID'], 'kecaName': k3, 'desa': 
                Object.entries(v3['Kelurahan/Desa']).map(([k4,v4]) => {
                  wilayahs.push({
                    id: v4['ID'],
                    prop: k1,
                    kabu: v2['Type'] === 'Kota' ? ('Kota ' + k2).replace(', Kota','') : ('Kabupaten ' + k2).replace(', Kabupaten', ''),
                    // kabu: k2,
                    keca: k3,
                    desa: k4,
                    kode: v4['Kode Pos']
                  })
                  return { 'id': v4['ID'], 'desaName': k4, 'kodepos': v4['Kode Pos'] };
                }) };
              }) };
            }) };
    });
    return wilayahs;
  }

</script>