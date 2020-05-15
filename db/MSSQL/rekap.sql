SELECT ROW_NUMBER() OVER (Order by KODE) [NO], * FROM
(
select dt1_id KODE, dt1_nm PROPINSI, count(distinct KOTA) KOTA, count(distinct KABU) KABUPATEN,count(distinct dt3_id) KECAMATAN, count(distinct dt4_id) KELURAHAN from
(
	select dt1.id dt1_id, dt1.nm dt1_nm, dt2.id dt2_id, dt2.nm dt2_nm, dt2.type dt2_type, case dt2.type when 'Kota' then dt2.id  end KOTA, case dt2.type when 'Kabupaten' then dt2.id end KABU,dt3.id dt3_id, dt3.nm dt3_nm  , dt4.id dt4_id, dt4.nm dt4_nm 
	from dt1
	inner join 
	(
		select id, nm , type from dt2
	)
	dt2 
	on dt1.id = left(dt2.id,2)
	inner join dt3
	on dt2.id = left(dt3.id,5)
	inner join dt4
	on dt3.id = left(dt4.id,8)
)a
group by dt1_id, dt1_nm 
)S
union all
select '','', 'TOTAL NASIONAL',(select COUNT(id) from dt2 where type='Kota'),(select COUNT(id) from dt2 where type='Kabupaten'),(select COUNT(id) from dt3),(select COUNT(id) from dt4)
order by KODE

